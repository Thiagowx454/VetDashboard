using System;
using System.Collections.Generic;

namespace VetDashboard.Models.Entities;

public partial class Agendamento
{
    public int IdAgendamento { get; set; }

    public int IdPaciente { get; set; }

    public int IdVeterinario { get; set; }

    public DateTime DataAgendamento { get; set; }

    public DateTime HoraAgendamento { get; set; }

    public string Observacoes { get; set; } = null!;

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;

    public virtual Veterinario IdVeterinarioNavigation { get; set; } = null!;

    public virtual Prontuario? Prontuario { get; set; }

    public virtual ICollection<Servico> Servicos { get; set; } = new List<Servico>();
}
