namespace VetDashboard.Models.Entities
{
    public class Veterinario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string Especialidade { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}