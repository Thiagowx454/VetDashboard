using System;
using System.Collections.Generic;

namespace VetDashboard.Models.Entities;

public partial class ItemEstoque
{
    public int IdProduto { get; set; }

    public string NomeProduto { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public int? Quantidade { get; set; }

    public decimal? PrecoCusto { get; set; }

    public decimal? PrecoVenda { get; set; }

    public string UnidadeMedida { get; set; } = null!;

    public DateTime? DataValidade { get; set; }

    public string Fornecedor { get; set; } = null!;

    public int? TransacaoDesejada { get; set; }

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Procedimento? Procedimento { get; set; }

    public virtual Servico? Servico { get; set; }

    public virtual Vacina? Vacina { get; set; }
}
