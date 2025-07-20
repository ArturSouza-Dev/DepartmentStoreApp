using System;
using System.Collections.Generic;

namespace DepartmentStoreApp.Models;

public partial class OrderLine
{
    public int OId { get; set; }

    public int InvId { get; set; }

    public int OlQuantity { get; set; }

    public virtual Inventory Inv { get; set; } = null!;

    public virtual Order OIdNavigation { get; set; } = null!;
}
