﻿using Domain.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMedicoService
    {
        Task<IList<MedicoDto>> GetAll();
        Task<MedicoDto> GetMedicoById(int medicoId);
        Task<int> AddMedico(MedicoDto medico);
        Task<int> AlterMedico(int id, MedicoDto medico);
        Task<int> DeleteMedicoById(int id);
        Task<int> UpdateMedicoSchedule(int idMedico, HorarioMedico horarioMedico);
        IEnumerable<Agenda> GetPendingConsultas(int idMedico);
    }
}
