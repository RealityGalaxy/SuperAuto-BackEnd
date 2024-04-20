using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketAnswersController : ControllerBase
    {
        private readonly ITicketAnswerService _ticketAnswerService;

        public TicketAnswersController(ITicketAnswerService ticketAnswerService)
        {
            _ticketAnswerService = ticketAnswerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ticketAnswers = _ticketAnswerService.GetAll();
            return Ok(ticketAnswers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ticketAnswer = _ticketAnswerService.GetById(id);
            if (ticketAnswer == null)
                return NotFound();

            return Ok(ticketAnswer);
        }

        [HttpPost("create")]
        public IActionResult Create(TicketAnswer ticketAnswer)
        {
            try
            {
                _ticketAnswerService.Create(ticketAnswer);
                return Ok(ticketAnswer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TicketAnswer ticketAnswer)
        {
            if (id != ticketAnswer.Id)
                return BadRequest();

            try
            {
                _ticketAnswerService.Update(ticketAnswer);
                return Ok(ticketAnswer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ticketAnswerService.Delete(id);
            return Ok();
        }
    }
}
