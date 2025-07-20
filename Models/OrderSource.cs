using System;
using System.Collections.Generic;

namespace DepartmentStoreApp.Models;

public partial class OrderSource
{
    public int OsId { get; set; }

    public string? OsDesc { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
