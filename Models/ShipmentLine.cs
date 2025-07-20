using System;
using System.Collections.Generic;

namespace DepartmentStoreApp.Models;

public partial class ShipmentLine
{
    public int ShipId { get; set; }

    public int InvId { get; set; }

    public int? SlQuantity { get; set; }

    public DateOnly? SlDateReceived { get; set; }

    public virtual Inventory Inv { get; set; } = null!;

    public virtual Shipment Ship { get; set; } = null!;
}
