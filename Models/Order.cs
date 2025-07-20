using System;
using System.Collections.Generic;

namespace DepartmentStoreApp.Models;

public partial class Order
{
    public int OId { get; set; }

    public DateOnly? ODate { get; set; }

    public string? OMethpmt { get; set; }

    public int? CId { get; set; }

    public int? OsId { get; set; }

    public virtual Customer? CIdNavigation { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual OrderSource? Os { get; set; }
}
