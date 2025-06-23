using System;
using System.Collections.Generic;

namespace VetDashboard.Models.Entities;

public partial class Servico
{
    public int IdServico { get; set; }

    public string TipoVenda { get; set; } = null!;

    public string NomeServico { get; set; } = null!;

    public int IdVeterinario { get; set; }

    public DateTime Data { get; set; }

    public DateTime Hora { get; set; }

    public int Status { get; set; }

    public decimal PrecoVenda { get; set; }

    public string Descricao { get; set; } = null!;

    public int IdAgendamento { get; set; }

    public int IdProduto { get; set; }

    public int IdValor { get; set; }

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Agendamento IdAgendamentoNavigation { get; set; } = null!;

    public virtual ItemEstoque IdProdutoNavigation { get; set; } = null!;

    public virtual Valor IdValorNavigation { get; set; } = null!;

    public virtual Veterinario IdVeterinarioNavigation { get; set; } = null!;
}
