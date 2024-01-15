using System;
using System.Collections.Generic;

namespace TMS_API.Models;

public partial class TicketsCategory
{
    public int TicketCategoryId { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public int? EventId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
