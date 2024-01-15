using System;
using System.Collections.Generic;

namespace TMS_API.Models;

public partial class Order
{
    public int OrdersId { get; set; }

    public int? NumberOfTickets { get; set; }

    public DateTime? OrderedAt { get; set; }

    public double? TotalPrice { get; set; }

    public int? TicketCategoryId { get; set; }

    public int? UserId { get; set; }

    public virtual TicketsCategory? TicketCategory { get; set; }

    public virtual User? User { get; set; }

    //
   // public virtual Event? Event { get; set;}





}
