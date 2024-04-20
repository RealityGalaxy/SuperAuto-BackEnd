using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Entities;
using WebApi.Models.Bills;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillsController : ControllerBase
    {
        private readonly IBillService _billService;
        private IMapper _mapper;

        public BillsController(IBillService billService, IMapper mapper)
        {
            _billService = billService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var bills = _billService.GetAll();
            return Ok(bills);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var bill = _billService.GetById(id);
            if (bill == null)
                return NotFound();

            return Ok(bill);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] BillCreateModel model)
        {
            try
            {
                Bill bill = _mapper.Map<Bill>(model);
                _billService.Create(bill);
                return Ok(bill);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Bill bill)
        {
            if (id != bill.Id)
                return BadRequest();

            try
            {
                _billService.Update(bill);
                return Ok(bill);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _billService.Delete(id);
            return Ok();
        }
    }
}
