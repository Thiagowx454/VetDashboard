namespace VetDashboard.Models.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public DateTime DataNascimento { get; set; }
        public int ProprietarioId { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual Proprietario Proprietario { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}