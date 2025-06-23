using System;
using System.Collections.Generic;

namespace VetDashboard.Models.Entities;

public partial class Vacina
{
    public int IdVacina { get; set; }

    public string NomeVacina { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public string Duracao { get; set; } = null!;

    public int IdProduto { get; set; }

    public int IdPaciente { get; set; }

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;

    public virtual ItemEstoque IdProdutoNavigation { get; set; } = null!;
}
