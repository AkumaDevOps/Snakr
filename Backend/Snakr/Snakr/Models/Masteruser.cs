using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class Masteruser
{
    public int Id { get; set; }

    public int IdMasterBranches { get; set; }

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();

    public virtual ICollection<Favouriteproduct> Favouriteproducts { get; set; } = new List<Favouriteproduct>();

    public virtual Masterbranch IdMasterBranchesNavigation { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<Usergrouppayment> Usergrouppayments { get; set; } = new List<Usergrouppayment>();

    public virtual ICollection<Mastergroup> IdMasterGroups { get; set; } = new List<Mastergroup>();
}
