using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetAll();
        Ticket GetById(int id);
        Ticket Create(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(int id);
    }

    public class TicketService : ITicketService
    {
        private readonly DataContext _context;
        private IUserService _userService;

        public TicketService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _context.Tickets;
        }

        public Ticket GetById(int id)
        {
            return _context.Tickets.Find(id);
        }

        public Ticket Create(Ticket ticket)
        {
            ticket.Creation_Date = DateTime.Now;
            ticket.Last_Answered_Date = DateTime.Now;
            ticket.Status = "created";

            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return ticket;
        }

        public void Update(Ticket ticket)
        {
            var existingTicket = _context.Tickets.Find(ticket.Id);
            if (existingTicket == null)
                throw new KeyNotFoundException("Ticket not found");

            if(ticket.Last_Answered_Date != existingTicket.Last_Answered_Date)
                existingTicket.Last_Answered_Date = ticket.Last_Answered_Date;
            if(ticket.Status != existingTicket.Status)
                existingTicket.Status = ticket.Status;

            _context.Tickets.Update(existingTicket);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
            }
        }
    }
}
