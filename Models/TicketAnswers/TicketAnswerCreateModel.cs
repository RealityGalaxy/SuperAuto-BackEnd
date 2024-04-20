using System;

namespace WebApi.Models.TicketAnswers
{
  public class TicketAnswerCreateModel
    {
        public string Content { get; set; }
        public int Author { get; set; }
        public int Ticket { get; set; }
    }
}