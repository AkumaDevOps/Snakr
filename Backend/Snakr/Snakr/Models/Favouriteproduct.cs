using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class Favouriteproduct
{
    public int Id { get; set; }

    public int IdMasterProducts { get; set; }

    public int IdMasterUsers { get; set; }

    public int IdMasterGroups { get; set; }

    public int? SugarQuantity { get; set; }

    public int OrderNumber { get; set; }

    public virtual Mastergroup IdMasterGroupsNavigation { get; set; } = null!;

    public virtual Masterproduct IdMasterProductsNavigation { get; set; } = null!;

    public virtual Masteruser IdMasterUsersNavigation { get; set; } = null!;
}
