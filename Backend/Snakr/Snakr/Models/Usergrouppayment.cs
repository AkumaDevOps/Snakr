using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class Usergrouppayment
{
    public int Id { get; set; }

    public int IdVendingMachinesBranches { get; set; }

    public int IdMasterGroups { get; set; }

    public int IdMasterUsers { get; set; }

    public int? NumberProducts { get; set; }

    public float? TotalExpended { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Mastergroup IdMasterGroupsNavigation { get; set; } = null!;

    public virtual Masteruser IdMasterUsersNavigation { get; set; } = null!;

    public virtual Vendingmachinesbranch IdVendingMachinesBranchesNavigation { get; set; } = null!;

    public virtual ICollection<Usergrouppaymentproduct> Usergrouppaymentproducts { get; set; } = new List<Usergrouppaymentproduct>();
}
