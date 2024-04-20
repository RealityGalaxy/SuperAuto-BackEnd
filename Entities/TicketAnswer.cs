using System;

namespace WebApi.Entities
{
    public class TicketAnswer
    {
        public int Id { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Content { get; set; }
        public int Author { get; set; }
        public int Ticket { get; set; }
    }
}
