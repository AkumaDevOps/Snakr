using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class Usergrouppaymentproduct
{
    public int Id { get; set; }

    public int IdUserGroupPayments { get; set; }

    public int IdMasterProducts { get; set; }

    public int? Quantity { get; set; }

    public float? PriceUnit { get; set; }

    public string? Currency { get; set; }

    public virtual Masterproduct IdMasterProductsNavigation { get; set; } = null!;

    public virtual Usergrouppayment IdUserGroupPaymentsNavigation { get; set; } = null!;
}
