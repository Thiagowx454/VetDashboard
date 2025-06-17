namespace VetDashboard.Models.Entities
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime DataConsulta { get; set; }
        public int VeterinarioId { get; set; }
        public int AnimalId { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; } // Agendada, Realizada, Cancelada
        public string Diagnostico { get; set; }
        public string Observacoes { get; set; }

        public virtual Veterinario Veterinario { get; set; }
        public virtual Animal Animal { get; set; }
    }
}