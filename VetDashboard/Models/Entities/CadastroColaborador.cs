using System;
using System.Collections.Generic;

namespace VetDashboard.Models.Entities;

public partial class CadastroColaborador
{
    public int IdColaborador { get; set; }

    public string Nome { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Rg { get; set; } = null!;

    public DateTime Dtnascimento { get; set; }

    public string Cep { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public int Cargo { get; set; }

    public int TipoUsuario { get; set; }

    public string IdentityUserId { get; set; } = null!;

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual AspNetUser IdentityUser { get; set; } = null!;

    public virtual Veterinario? Veterinario { get; set; }
}
