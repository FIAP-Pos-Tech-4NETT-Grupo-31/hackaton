using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class HorarioMedico
    {
        public string DuracaoConsulta { get; set; }
        public string? Dom { get; set; }
        public string? Seg { get; set; }
        public string? Ter { get; set; }
        public string? Qua { get; set; }
        public string? Qui{ get; set; }
        public string? Sex { get; set; }
        public string? Sab { get; set; }
    }
}
