using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class Mastervendingmachine
{
    public int Id { get; set; }

    public string MachineName { get; set; } = null!;

    public string? Model { get; set; }

    public string Brand { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual ICollection<Vendingmachinesbranch> Vendingmachinesbranches { get; set; } = new List<Vendingmachinesbranch>();
}
