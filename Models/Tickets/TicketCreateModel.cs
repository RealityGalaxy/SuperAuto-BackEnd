using System;

namespace WebApi.Models.Tickets
{
  public class TicketCreateModel
    {
        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public DateTime LastAnsweredDate { get; set; }
        public string Status { get; set; }
        public int Author { get; set; }
    }
}