using System;
using System.Collections.Generic;

namespace VetDashboard.Models.Entities;

public partial class AgendaVeterinario
{
    public int IdAgendaVeterinario { get; set; }

    public int IdVeterinario { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public int IdPaciente { get; set; }

    public int? PacienteIdPaciente { get; set; }

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Veterinario IdVeterinarioNavigation { get; set; } = null!;

    public virtual Paciente? PacienteIdPacienteNavigation { get; set; }
}
