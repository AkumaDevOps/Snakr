using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class Usergroupsmachinesreservation
{
    public int Id { get; set; }

    public int IdVendingMachinesBranches { get; set; }

    public int IdMasterGroup { get; set; }

    public DateTime TimeReserve { get; set; }

    public int Minutes { get; set; }

    public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();

    public virtual Mastergroup IdMasterGroupNavigation { get; set; } = null!;

    public virtual Vendingmachinesbranch IdVendingMachinesBranchesNavigation { get; set; } = null!;
}
