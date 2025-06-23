using System;
using System.Collections.Generic;

namespace VetDashboard.Models.Entities;

public partial class Procedimento
{
    public int IdProcedimento { get; set; }

    public string NomeProcedimento { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public decimal Valor { get; set; }

    public int IdProduto { get; set; }

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ItemEstoque IdProdutoNavigation { get; set; } = null!;
}
