using System;

namespace WebApi.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Content { get; set; }
        public DateTime Last_Answered_Date { get; set; }
        public string Status { get; set; }
        public int Author { get; set; }
    }
}
