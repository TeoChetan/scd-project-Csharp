namespace TMS_API.Models.DTO
{
    public class OrdersDTO
    {
        public int OrdersId { get; set; }
        public int NumberOfTickets { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderedAt { get; set; }
        // public int TicketCategoryId { get; set; }
       
        //
        public TicketsCategoryDTO TicketsCategory { get; set; }

       // public string? Events { get; set; }



    }
}
