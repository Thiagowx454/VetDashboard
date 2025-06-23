namespace VetDashboard.Models.DTOs
{
    public class ChartDataDto
    {
        public string Label { get; set; }
        public decimal Value { get; set; }
        public int Count { get; set; } // Adicionamos Count para gráficos de quantidade
    }
}