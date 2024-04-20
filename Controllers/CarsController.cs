using System;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;
using WebApi.Entities;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using WebApi.Models.Cars;
using AutoMapper;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private IMapper _mapper;

        public CarsController(ICarService carService, IMapper mapper)
        {
            _mapper = mapper;
            _carService = carService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var cars = _carService.GetAll();
            return Ok(cars);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CarCreateModel model)
        {
            try
            {
                Car car = _mapper.Map<Car>(model);
                _carService.Create(car);
                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var car = _carService.GetById(id);
            if (car == null)
                return NotFound();

            return Ok(car);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Car car)
        {
            if (id != car.Id)
                return BadRequest();

            try
            {
                _carService.Update(car);
                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _carService.Delete(id);
            return Ok();
        }
    }
}
