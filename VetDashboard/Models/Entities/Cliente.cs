using System;
using System.Collections.Generic;

namespace VetDashboard.Models.Entities;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NomeResponsavel { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Rg { get; set; } = null!;

    public DateTime DtNascimento { get; set; }

    public string Cep { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

    public virtual ICollection<Valor> Valors { get; set; } = new List<Valor>();
}
