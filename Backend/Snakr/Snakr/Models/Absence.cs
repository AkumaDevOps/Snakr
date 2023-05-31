using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class Absence
{
    public int IdMasterUsers { get; set; }

    public int IdMasterGroups { get; set; }

    public int IdUserGroupsMachinesReservations { get; set; }

    public virtual Mastergroup IdMasterGroupsNavigation { get; set; } = null!;

    public virtual Masteruser IdMasterUsersNavigation { get; set; } = null!;

    public virtual Usergroupsmachinesreservation IdUserGroupsMachinesReservationsNavigation { get; set; } = null!;
}
