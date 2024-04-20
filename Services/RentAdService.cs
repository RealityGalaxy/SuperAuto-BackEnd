using System;
using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IRentAdService
    {
        IEnumerable<RentAd> GetAll();
        RentAd GetById(int id);
        RentAd Create(RentAd rentAd);
        void Update(RentAd rentAd);
        void Delete(int id);
    }

    public class RentAdService : IRentAdService
    {
        private readonly DataContext _context;

        public RentAdService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<RentAd> GetAll()
        {
            return _context.Rent_Ads;
        }

        public RentAd GetById(int id)
        {
            return _context.Rent_Ads.Find(id);
        }

        public RentAd Create(RentAd rentAd)
        {
            _context.Rent_Ads.Add(rentAd);
            _context.SaveChanges();
            return rentAd;
        }

        public void Update(RentAd rentAd)
        {
            var existingRentAd = _context.Rent_Ads.Find(rentAd.Id);
            if (existingRentAd == null)
                throw new KeyNotFoundException("RentAd not found");

            if(existingRentAd.Deposit != rentAd.Deposit)
                existingRentAd.Deposit = rentAd.Deposit;

            if(existingRentAd.Price != rentAd.Price)
                existingRentAd.Price = rentAd.Price;

            if(existingRentAd.Term != rentAd.Term)
                existingRentAd.Term = rentAd.Term;

            _context.Rent_Ads.Update(existingRentAd);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var rentAd = _context.Rent_Ads.Find(id);
            if (rentAd != null)
            {
                _context.Rent_Ads.Remove(rentAd);
                _context.SaveChanges();
            }
        }
    }
}
