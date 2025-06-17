namespace VetDashboard.Models.DTOs
{
    public class ConsultasPorMesDto
    {
        public string Mes { get; set; }
        public int Quantidade { get; set; } // ← ESTA PROPRIEDADE ESTAVA FALTANDO
        public decimal Receita { get; set; }
    }
}