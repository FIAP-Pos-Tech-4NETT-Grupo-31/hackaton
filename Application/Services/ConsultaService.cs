using Application.Interfaces;
using Domain.Dtos;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IMedicoService _medicoService;
        private readonly IPacienteService _pacienteService;
        private readonly IAgendaRepository _agendaRepository;
        private readonly IEmailService _emailService;

        public ConsultaService(IMedicoService medicoService, IAgendaRepository agendaRepository, IPacienteService pacienteService, IEmailService emailService) {
            _medicoService = medicoService;
            _agendaRepository = agendaRepository;
            _pacienteService = pacienteService;
            _emailService = emailService;
        }

        public HorarioMedico ConvertHorarioMedico(string horarioMedico)
        {
            string pattern = @"Dur:(\d+);(?:((?:Dom|Seg|Ter|Qua|Qui|Sex|Sab)_\d{2}:\d{2}-\d{2}:\d{2};)*)";
            Match match = Regex.Match(horarioMedico, pattern);

            if (!match.Success)
            {
                throw new FormatException("Formato inválido!");
            }

            HorarioMedico horario = new()
            {
                DuracaoConsulta = match.Groups[1].Value
            };

            string daysPattern = @"(Dom|Seg|Ter|Qua|Qui|Sex|Sab)_(\d{2}:\d{2}-\d{2}:\d{2});";
            foreach (Match dayMatch in Regex.Matches(horarioMedico, daysPattern))
            {
                string day = dayMatch.Groups[1].Value;
                string hours = dayMatch.Groups[2].Value;

                switch (day)
                {
                    case "Dom": horario.Dom = hours; break;
                    case "Seg": horario.Seg = hours; break;
                    case "Ter": horario.Ter = hours; break;
                    case "Qua": horario.Qua = hours; break;
                    case "Qui": horario.Qui = hours; break;
                    case "Sex": horario.Sex = hours; break;
                    case "Sab": horario.Sab = hours; break;
                }
            }

            return horario;
        }

        public async Task<HorarioMedico?> GetHorariosMedico(int idMedico)
        {
            var medico = await _medicoService.GetMedicoById(idMedico);
            if (medico == null) return null;

            var horarioMedico = ConvertHorarioMedico(medico.Horarios);
            return horarioMedico;
        }

        public async Task<bool> ScheduleWithMedico(DateTime scheduleMedico, int idMedico, string userEmail)
        {
            var isMedicoAvailable = false;
            var horarios = await GetHorariosMedico(idMedico);

            var currentDay = scheduleMedico.DayOfWeek;
            var wantedHour = scheduleMedico.ToString("HH:mm");

            switch (currentDay)
            {
                case DayOfWeek.Sunday: isMedicoAvailable = CheckMedicoAvailability(wantedHour, horarios.Dom); break;
                case DayOfWeek.Monday: isMedicoAvailable = CheckMedicoAvailability(wantedHour, horarios.Seg); break;
                case DayOfWeek.Tuesday: isMedicoAvailable = CheckMedicoAvailability(wantedHour, horarios.Ter); break;
                case DayOfWeek.Wednesday: isMedicoAvailable = CheckMedicoAvailability(wantedHour, horarios.Qua); break;
                case DayOfWeek.Thursday: isMedicoAvailable = CheckMedicoAvailability(wantedHour, horarios.Qui); break;
                case DayOfWeek.Friday: isMedicoAvailable = CheckMedicoAvailability(wantedHour, horarios.Sex); break;
                case DayOfWeek.Saturday: isMedicoAvailable = CheckMedicoAvailability(wantedHour, horarios.Sab); break;
                default: break;
            }

            var agendaMedicoThatDay = _agendaRepository.MedicoDailyAppointments(idMedico, scheduleMedico);            

            foreach(var a in agendaMedicoThatDay)
            {
                var appointmentStartHour = $"{a.DataConsulta.Hour.ToString("D2")}:{a.DataConsulta.Minute.ToString("D2")}";
                var appointmentEndHourDate = a.DataConsulta.AddMinutes(Convert.ToInt16(horarios.DuracaoConsulta));
                var appointmentEndHour = $"{appointmentEndHourDate.Hour.ToString("D2")}:{appointmentEndHourDate.Minute.ToString("D2")}";

                if ((wantedHour.CompareTo(appointmentStartHour) >= 0 && wantedHour.CompareTo(appointmentEndHour) < 0)) {
                    isMedicoAvailable = false; break;
                };

            }

            if (isMedicoAvailable) {
                var paciente = _pacienteService.GetPacienteByMail(userEmail);
                if (paciente != null)
                {
                    var medico = await _medicoService.GetMedicoById(idMedico);
                    await _agendaRepository.AddAppointment(idMedico, paciente.Id, scheduleMedico);
                    
                    /*
                    var mailBody = new StringBuilder();
                    mailBody.AppendLine($"Olá, {medico.Nome}!");
                    mailBody.AppendLine($"Você tem uma nova consulta marcada! Paciente: {paciente.Nome}");
                    mailBody.AppendLine($"Data e horário: {scheduleMedico.ToString("dd/MM/yyyy")} às {wantedHour}.");
                    await _emailService.SendEmailAsync(medico.Email, "Health & Med - Nova consulta agendada", mailBody.ToString());                    
                    */
                }
            }

            return isMedicoAvailable;
        }

        public bool CheckMedicoAvailability(string wantedHour, string medicoRange)
        {
            var initTime = medicoRange.Split("-")[0];
            var endTime = medicoRange.Split("-")[1];

            if (wantedHour.CompareTo(initTime) >= 0 && wantedHour.CompareTo(endTime) <= 0) return true;
            else return false;
        }

        public async Task<bool> ApproveOrDeleteConsulta(int idConsulta, bool approveOrReprove)
        {
            if (approveOrReprove) await _agendaRepository.ApproveConsulta(idConsulta);
            else await _agendaRepository.DeleteConsulta(idConsulta);

            return true;
        }
    }
}
