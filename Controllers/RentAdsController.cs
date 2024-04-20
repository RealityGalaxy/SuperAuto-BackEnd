using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Entities;
using WebApi.Models.RentAds;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentAdsController : ControllerBase
    {
        private readonly IRentAdService _rentAdService;

        public RentAdsController(IRentAdService rentAdService)
        {
            _rentAdService = rentAdService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var rentAds = _rentAdService.GetAll();
            return Ok(rentAds);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var rentAd = _rentAdService.GetById(id);
            if (rentAd == null)
                return NotFound();

            return Ok(rentAd);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] RentAdCreateModel model)
        {
            try
            {
                RentAd rentAd = new RentAd();
                rentAd.Deposit = model.Deposit;
                rentAd.Price = model.Price;
                rentAd.Term = model.Term;
                rentAd.Creation_Date = DateTime.Now;
                rentAd.Expiry_Date = DateTime.Now.AddDays(model.Days);
                rentAd.Car = model.Car;
                rentAd.Author = model.Author;

                _rentAdService.Create(rentAd);
                return Ok(rentAd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, RentAd rentAd)
        {
            if (id != rentAd.Id)
                return BadRequest();

            try
            {
                _rentAdService.Update(rentAd);
                return Ok(rentAd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _rentAdService.Delete(id);
            return Ok();
        }
    }
}
