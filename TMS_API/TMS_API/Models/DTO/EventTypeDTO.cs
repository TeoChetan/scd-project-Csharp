﻿namespace TMS_API.Models.DTO
{
    public class EventTypeDTO
    {
        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; }
        public ICollection<Event>? Events { get; set; }
    }
}
