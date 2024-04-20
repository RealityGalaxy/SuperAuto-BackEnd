using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Entities;
using WebApi.Models.SaleAds;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleAdsController : ControllerBase
    {
        private readonly ISaleAdService _saleAdService;

        public SaleAdsController(ISaleAdService saleAdService)
        {
            _saleAdService = saleAdService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var saleAds = _saleAdService.GetAll();
            return Ok(saleAds);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var saleAd = _saleAdService.GetById(id);
            if (saleAd == null)
                return NotFound();

            return Ok(saleAd);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] SaleAdCreateModel model)
        {
            try
            {
                SaleAd saleAd = new SaleAd();
                saleAd.Price = model.Price;
                saleAd.Creation_Date = DateTime.Now;
                saleAd.Expiry_Date = DateTime.Now.AddDays(model.Days);
                saleAd.Car = model.Car;
                saleAd.Author = model.Author;

                _saleAdService.Create(saleAd);
                return Ok(saleAd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SaleAd saleAd)
        {
            if (id != saleAd.Id)
                return BadRequest();

            try
            {
                _saleAdService.Update(saleAd);
                return Ok(saleAd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _saleAdService.Delete(id);
            return Ok();
        }
    }
}
