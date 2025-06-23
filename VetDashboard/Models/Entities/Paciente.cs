using System;
using System.Collections.Generic;

namespace VetDashboard.Models.Entities;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public int IdCliente { get; set; }

    public string NomeCachorro { get; set; } = null!;

    public int Estado { get; set; }

    public string Problema { get; set; } = null!;

    public int TipoAtendimento { get; set; }

    public float Peso { get; set; }

    public string SinaisVitais { get; set; } = null!;

    public string Recomendacoes { get; set; } = null!;

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<AgendaVeterinario> AgendaVeterinarios { get; set; } = new List<AgendaVeterinario>();

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<Prontuario> Prontuarios { get; set; } = new List<Prontuario>();

    public virtual ICollection<Vacina> Vacinas { get; set; } = new List<Vacina>();
}
