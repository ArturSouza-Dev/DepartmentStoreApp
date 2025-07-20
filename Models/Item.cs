using System;
using System.Collections.Generic;

namespace DepartmentStoreApp.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string? ItemDesc { get; set; }

    public int? CatId { get; set; }

    public byte[]? ItemImage { get; set; }

    public virtual Category? Cat { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
