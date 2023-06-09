using System;
using System.Collections.Generic;

namespace Snakr.Models;

public partial class Masterproduct
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<FavouriteProductDTO> Favouriteproducts { get; set; } = new List<FavouriteProductDTO>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<Usergrouppaymentproduct> Usergrouppaymentproducts { get; set; } = new List<Usergrouppaymentproduct>();

    public virtual ICollection<Vendingmachinesbranchesproduct> Vendingmachinesbranchesproducts { get; set; } = new List<Vendingmachinesbranchesproduct>();

    public virtual ICollection<Vendingrefill> Vendingrefills { get; set; } = new List<Vendingrefill>();
}
