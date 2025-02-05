namespace WebAPI.Models.Requests
{
    public class HorarioMedicoRequest
    {
        public int DuracaoConsulta { get; set; }
        public string? DomInit { get; set; }
        public string? DomEnd { get; set; }
        public string? SegInit { get; set; }
        public string? SegEnd { get; set; }
        public string? TerInit { get; set; }
        public string? TerEnd { get; set; }
        public string? QuaInit { get; set; }
        public string? QuaEnd { get; set; }
        public string? QuiInit { get; set; }
        public string? QuiEnd { get; set; }
        public string? SexInit { get; set; }
        public string? SexEnd { get; set; }
        public string? SabInit { get; set; }
        public string? SabEnd { get; set; }
        
    }
}
