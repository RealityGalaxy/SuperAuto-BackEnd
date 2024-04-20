using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tickets = _ticketService.GetAll();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ticket = _ticketService.GetById(id);
            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpPost("create")]
        public IActionResult Create(Ticket ticket)
        {
            try
            {
                _ticketService.Create(ticket);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Ticket ticket)
        {
            if (id != ticket.Id)
                return BadRequest();

            try
            {
                _ticketService.Update(ticket);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ticketService.Delete(id);
            return Ok();
        }
    }
}
