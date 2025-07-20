using System;
using System.Collections.Generic;

namespace DepartmentStoreApp.Models;

public partial class Color
{
    public string Color1 { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
