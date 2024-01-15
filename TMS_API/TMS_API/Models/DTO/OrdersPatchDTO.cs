namespace TMS_API.Models.DTO
{
    public class OrdersPatchDTO
    {
        public int OrdersId { get; set; }
        public int NumberOfTickets { get; set; }
        //public double TotalPrice { get; set; }
        //public DateTime OrderedAt { get; set; }
        public int TicketCategoryId { get; set; }


    }
}
