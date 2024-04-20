using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestsController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var requests = _requestService.GetAll();
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var request = _requestService.GetById(id);
            if (request == null)
                return NotFound();

            return Ok(request);
        }

        [HttpPost("create")]
        public IActionResult Create(Request request)
        {
            try
            {
                _requestService.Create(request);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Request request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                _requestService.Update(request);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _requestService.Delete(id);
            return Ok();
        }
    }
}
