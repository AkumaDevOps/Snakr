using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class Masterbranch
{
    public int Id { get; set; }

    public string BranchName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Masteruser> Masterusers { get; set; } = new List<Masteruser>();

    public virtual ICollection<Vendingmachinesbranch> Vendingmachinesbranches { get; set; } = new List<Vendingmachinesbranch>();
}
