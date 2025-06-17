namespace VetDashboard.Models.Entities
{
    public class Proprietario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<Animal> Animais { get; set; }
    }
}