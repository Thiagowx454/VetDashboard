using VetDashboard.Models.DTOs;

namespace VetDashboard.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalConsultas { get; set; }
        public int TotalAnimais { get; set; }
        public int TotalVeterinarios { get; set; }
        public decimal ReceitaMensal { get; set; }
        public decimal ReceitaTotal { get; set; }
        public int ConsultasHoje { get; set; }
        public int ConsultasEsteMes { get; set; }

        public List<ConsultasPorMesDto> ConsultasPorMes { get; set; } = new List<ConsultasPorMesDto>();
        public List<ReceitaPorVeterinarioDto> ReceitaPorVeterinario { get; set; } = new List<ReceitaPorVeterinarioDto>();
        public List<AnimaisPorEspecieDto> AnimaisPorEspecie { get; set; } = new List<AnimaisPorEspecieDto>();
    }
}