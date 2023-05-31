using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class Purchase
{
    public int Id { get; set; }

    public int IdMasterProducts { get; set; }

    public int IdMasterProvider { get; set; }

    public int? Quantity { get; set; }

    public float? PriceUnit { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public virtual Masterproduct IdMasterProductsNavigation { get; set; } = null!;

    public virtual Masterprovider IdMasterProviderNavigation { get; set; } = null!;
}
