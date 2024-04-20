using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IBillService
    {
        IEnumerable<Bill> GetAll();
        Bill GetById(int id);
        Bill Create(Bill bill);
        void Update(Bill bill);
        void Delete(int id);
    }

    public class BillService : IBillService
    {
        private readonly DataContext _context;

        public BillService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Bill> GetAll()
        {
            return _context.Bills;
        }

        public Bill GetById(int id)
        {
            return _context.Bills.Find(id);
        }

        public Bill Create(Bill bill)
        {
            _context.Bills.Add(bill);
            _context.SaveChanges();
            return bill;
        }

        public void Update(Bill bill)
        {
            var existingBill = _context.Bills.Find(bill.Id);
            if (existingBill == null)
                throw new KeyNotFoundException("Bill not found");

            // Update properties
            // Add other properties as needed
            if(bill.Payer != existingBill.Payer)
                existingBill.Payer = bill.Payer;
            if(bill.Sum != existingBill.Sum)
                existingBill.Sum = bill.Sum;
            if(bill.Type != existingBill.Type)
                existingBill.Type = bill.Type;


            _context.Bills.Update(existingBill);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var bill = _context.Bills.Find(id);
            if (bill != null)
            {
                _context.Bills.Remove(bill);
                _context.SaveChanges();
            }
        }
    }
}
