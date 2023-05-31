using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class Vendingmachinesbranch
{
    public int Id { get; set; }

    public int IdMasterVendingMachines { get; set; }

    public int IdMasterBranches { get; set; }

    public string? BuildingName { get; set; }

    public int? Floor { get; set; }

    public string? Notes { get; set; }

    public virtual Masterbranch IdMasterBranchesNavigation { get; set; } = null!;

    public virtual Mastervendingmachine IdMasterVendingMachinesNavigation { get; set; } = null!;

    public virtual ICollection<Usergrouppayment> Usergrouppayments { get; set; } = new List<Usergrouppayment>();

    public virtual ICollection<Usergroupsmachinesreservation> Usergroupsmachinesreservations { get; set; } = new List<Usergroupsmachinesreservation>();

    public virtual ICollection<Vendingmachinesbranchesproduct> Vendingmachinesbranchesproducts { get; set; } = new List<Vendingmachinesbranchesproduct>();

    public virtual ICollection<Vendingrefill> Vendingrefills { get; set; } = new List<Vendingrefill>();
}
