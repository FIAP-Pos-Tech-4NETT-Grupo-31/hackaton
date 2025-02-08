﻿namespace Domain.Entities
{
    public class Agenda
    {
        public int Id { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
    }
}
