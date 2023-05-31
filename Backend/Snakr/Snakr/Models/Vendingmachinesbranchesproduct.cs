using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class Vendingmachinesbranchesproduct
{
    public int Id { get; set; }

    public int IdVendingMachinesBranches { get; set; }

    public int IdMasterProduct { get; set; }

    public int? AsociatedNumber { get; set; }

    public float? Price { get; set; }

    public string? Currency { get; set; }

    public virtual Masterproduct IdMasterProductNavigation { get; set; } = null!;

    public virtual Vendingmachinesbranch IdVendingMachinesBranchesNavigation { get; set; } = null!;
}
