using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class Request
{
    public int Id { get; set; }

    public int IdMasterUser { get; set; }

    public int IdMasterProducts { get; set; }

    public int? SugarQuantity { get; set; }

    public string? Notes { get; set; }

    public virtual Masterproduct IdMasterProductsNavigation { get; set; } = null!;

    public virtual Masteruser IdMasterUserNavigation { get; set; } = null!;
}
