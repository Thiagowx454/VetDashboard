using System;
using System.Collections.Generic;

namespace VetDashboard.Models.Entities;

public partial class Veterinario
{
    public int IdVeterinario { get; set; }

    public string NomeVeterinario { get; set; } = null!;

    public string Especialidade { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int IdColaborador { get; set; }

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<AgendaVeterinario> AgendaVeterinarios { get; set; } = new List<AgendaVeterinario>();

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    public virtual CadastroColaborador IdColaboradorNavigation { get; set; } = null!;

    public virtual ICollection<Prontuario> Prontuarios { get; set; } = new List<Prontuario>();

    public virtual ICollection<Servico> Servicos { get; set; } = new List<Servico>();
}
