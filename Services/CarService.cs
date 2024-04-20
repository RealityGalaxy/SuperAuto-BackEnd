using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface ICarService
    {
        IEnumerable<Car> GetAll();
        Car GetById(int id);
        Car Create(Car car);
        void Update(Car car);
        void Delete(int id);
    }

    public class CarService : ICarService
    {
        private readonly DataContext _context;

        public CarService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars;
        }

        public Car GetById(int id)
        {
            return _context.Cars.Find(id);
        }

        public Car Create(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return car;
        }

        public void Update(Car car)
        {
            var existingCar = _context.Cars.Find(car.Id);
            if (existingCar == null)
                throw new KeyNotFoundException("Car not found");

            if(car.Make != existingCar.Make)
                existingCar.Make = car.Make;

            if (car.Model != existingCar.Model)
                existingCar.Model = car.Model;

            if (car.License_Plate != existingCar.License_Plate)
                existingCar.License_Plate = car.License_Plate;

            if (car.Creation_Date != existingCar.Creation_Date)
                existingCar.Creation_Date = car.Creation_Date;

            if( car.Seats != existingCar.Seats)
                existingCar.Seats = car.Seats;

            if (car.Description != existingCar.Description)
                existingCar.Description = car.Description;

            if (car.Transmission != existingCar.Transmission)
                existingCar.Transmission = car.Transmission;

            if (car.Fuel_Type != existingCar.Fuel_Type)
                existingCar.Fuel_Type = car.Fuel_Type;

            if (car.Body_Type != existingCar.Body_Type)
                existingCar.Body_Type = car.Body_Type;

            if (car.State != existingCar.State)
                existingCar.State = car.State;

            if (car.Image != existingCar.Image)
                existingCar.Image = car.Image;


            _context.Cars.Update(existingCar);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }
    }
}
