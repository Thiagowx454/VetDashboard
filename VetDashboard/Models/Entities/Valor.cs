using System;
using System.Collections.Generic;

namespace VetDashboard.Models.Entities;

public partial class Valor
{
    public int IdValor { get; set; }

    public decimal ValorProcedimento { get; set; }

    public string TipoPagamento { get; set; } = null!;

    public decimal ValorReceita { get; set; }

    public decimal ValorSaida { get; set; }

    public decimal Salario { get; set; }

    public decimal CompraProdutos { get; set; }

    public int IdCliente { get; set; }

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Servico? Servico { get; set; }
}
