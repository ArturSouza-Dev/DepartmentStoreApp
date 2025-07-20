using System;
using System.Collections.Generic;

namespace DepartmentStoreApp.Models;

public partial class Category
{
    public int CatId { get; set; }

    public string? CatDesc { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
