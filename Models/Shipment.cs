using System;
using System.Collections.Generic;

namespace DepartmentStoreApp.Models;

public partial class Shipment
{
    public int ShipId { get; set; }

    public DateOnly? ShipDateExpected { get; set; }

    public virtual ICollection<ShipmentLine> ShipmentLines { get; set; } = new List<ShipmentLine>();
}
