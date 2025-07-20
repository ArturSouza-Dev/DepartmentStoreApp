using System;
using System.Collections.Generic;

namespace DepartmentStoreApp.Models;

public partial class Inventory
{
    public int InvId { get; set; }

    public int? ItemId { get; set; }

    public string? Color { get; set; }

    public string? InvSize { get; set; }

    public decimal? InvPrice { get; set; }

    public int? InvQoh { get; set; }

    public virtual Color? ColorNavigation { get; set; }

    public virtual Item? Item { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual ICollection<ShipmentLine> ShipmentLines { get; set; } = new List<ShipmentLine>();
}
