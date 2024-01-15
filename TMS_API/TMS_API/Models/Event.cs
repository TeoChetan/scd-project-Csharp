using System;
using System.Collections.Generic;

namespace TMS_API.Models;

public partial class Event
{
    public int EventId { get; set; }

    public DateTime? EndDate { get; set; }

    public string? EventDescription { get; set; }

    public string? EventName { get; set; }

    public DateTime? StartDate { get; set; }

    public int? EventTypeId { get; set; }

    public int? VenueId { get; set; }

    public virtual EventsType? EventType { get; set; }

    public virtual ICollection<TicketsCategory> TicketsCategories { get; set; } = new List<TicketsCategory>();

    public virtual Venue? Venue { get; set; }
   


}
