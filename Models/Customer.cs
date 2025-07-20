using System;
using System.Collections.Generic;

namespace DepartmentStoreApp.Models;

public partial class Customer
{
    public int CId { get; set; }

    public string? CLast { get; set; }

    public string? CFirst { get; set; }

    public string? CMi { get; set; }

    public DateOnly? CBirthdate { get; set; }

    public string? CAddress { get; set; }

    public string? CCity { get; set; }

    public string? CState { get; set; }

    public string? CZip { get; set; }

    public string? CDphone { get; set; }

    public string? CEphone { get; set; }

    public string? CUserid { get; set; }

    public string? CPassword { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
