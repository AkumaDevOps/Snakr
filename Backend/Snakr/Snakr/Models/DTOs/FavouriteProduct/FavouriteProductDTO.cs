using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class FavouriteProductDTO
{
    public int Id { get; set; }

    public int IdMasterProducts { get; set; }

    public int IdMasterUsers { get; set; }

    public int IdMasterGroups { get; set; }

    public int? SugarQuantity { get; set; }

    public int OrderNumber { get; set; }

}
