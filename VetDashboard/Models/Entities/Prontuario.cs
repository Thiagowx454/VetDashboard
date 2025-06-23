using System;
using System.Collections.Generic;

namespace VetDashboard.Models.Entities;

public partial class Prontuario
{
    public int IdProntuario { get; set; }

    public int? IdAgendamento { get; set; }

    public int? IdVeterinario { get; set; }

    public DateTime DataConsulta { get; set; }

    public string MotivoConsulta { get; set; } = null!;

    public string Diagnostico { get; set; } = null!;

    public string Tratamento { get; set; } = null!;

    public float? Peso { get; set; }

    public int? Temperatura { get; set; }

    public int? FrequenciaCardiaca { get; set; }

    public int? FrequenciaRespiratoria { get; set; }

    public string Observacoes { get; set; } = null!;

    public int IdPaciente { get; set; }

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Agendamento? IdAgendamentoNavigation { get; set; }

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;

    public virtual Veterinario? IdVeterinarioNavigation { get; set; }
}
