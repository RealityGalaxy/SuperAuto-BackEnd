using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface ITicketAnswerService
    {
        IEnumerable<TicketAnswer> GetAll();
        TicketAnswer GetById(int id);
        TicketAnswer Create(TicketAnswer ticketAnswer);
        void Update(TicketAnswer ticketAnswer);
        void Delete(int id);
    }

    public class TicketAnswerService : ITicketAnswerService
    {
        private readonly DataContext _context;
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;

        public TicketAnswerService(DataContext context, ITicketService ticketService, IUserService userService)
        {
            _context = context;
            _ticketService = ticketService;
            _userService = userService;
        }

        public IEnumerable<TicketAnswer> GetAll()
        {
            return _context.Ticket_Answers;
        }

        public TicketAnswer GetById(int id)
        {
            return _context.Ticket_Answers.Find(id);
        }

        public TicketAnswer Create(TicketAnswer ticketAnswer)
        {
            ticketAnswer.Creation_Date = DateTime.Now;

            Ticket ticket = _ticketService.GetById(ticketAnswer.Ticket);
            User user = _userService.GetById(ticketAnswer.Author);
            User owner = _userService.GetById(ticket.Author);

            ticket.Status = user.Type == "admin" ? "answered" : "updated";
            ticket.Last_Answered_Date = DateTime.Now;

            if(user.Type == "admin")
            {
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("tocelisovidijus@gmail.com", "SuperAuto.pl");
                var subject = "Gavote atsakyma i bilieta - " + ticket.Title;
                var to = new EmailAddress(owner.Email, "Atsakymo gavejas");
                var plainTextContent = ticketAnswer.Content;
                var htmlContent = ticketAnswer.Content;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                client.SendEmailAsync(msg);
            }

            _ticketService.Update(ticket);


            _context.Ticket_Answers.Add(ticketAnswer);
            _context.SaveChanges();
            return ticketAnswer;
        }

        public void Update(TicketAnswer ticketAnswer)
        {
            var existingTicketAnswer = _context.Ticket_Answers.Find(ticketAnswer.Id);
            if (existingTicketAnswer == null)
                throw new KeyNotFoundException("TicketAnswer not found");
            // Add other properties as needed

            _context.Ticket_Answers.Update(existingTicketAnswer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ticketAnswer = _context.Ticket_Answers.Find(id);
            if (ticketAnswer != null)
            {
                _context.Ticket_Answers.Remove(ticketAnswer);
                _context.SaveChanges();
            }
        }
    }
}
