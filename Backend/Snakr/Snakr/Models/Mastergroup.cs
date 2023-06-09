using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class Mastergroup
{
    public int Id { get; set; }

    public int IdMasterBranches { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();

    public virtual ICollection<Favouriteproduct> Favouriteproducts { get; set; } = new List<Favouriteproduct>();

    public virtual ICollection<Usergrouppayment> Usergrouppayments { get; set; } = new List<Usergrouppayment>();

    public virtual ICollection<Usergroupsmachinesreservation> Usergroupsmachinesreservations { get; set; } = new List<Usergroupsmachinesreservation>();

    public virtual ICollection<Masteruser> IdMasterUsers { get; set; } = new List<Masteruser>();
}
