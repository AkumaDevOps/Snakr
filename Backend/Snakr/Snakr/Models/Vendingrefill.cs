using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class Vendingrefill
{
    public int Id { get; set; }

    public int IdVendingMachinesBranches { get; set; }

    public int IdProduct { get; set; }

    public int? IdEmployee { get; set; }

    public int? Quantity { get; set; }

    public int? CodeNumberMachine { get; set; }

    public DateTime? Date { get; set; }

    public string? Notes { get; set; }

    public virtual Masterproduct IdProductNavigation { get; set; } = null!;

    public virtual Vendingmachinesbranch IdVendingMachinesBranchesNavigation { get; set; } = null!;
}
