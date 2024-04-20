using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface ISaleAdService
    {
        IEnumerable<SaleAd> GetAll();
        SaleAd GetById(int id);
        SaleAd Create(SaleAd saleAd);
        void Update(SaleAd saleAd);
        void Delete(int id);
    }

    public class SaleAdService : ISaleAdService
    {
        private readonly DataContext _context;

        public SaleAdService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<SaleAd> GetAll()
        {
            return _context.Sale_Ads;
        }

        public SaleAd GetById(int id)
        {
            return _context.Sale_Ads.Find(id);
        }

        public SaleAd Create(SaleAd saleAd)
        {
            _context.Sale_Ads.Add(saleAd);
            _context.SaveChanges();
            return saleAd;
        }

        public void Update(SaleAd saleAd)
        {
            var existingSaleAd = _context.Sale_Ads.Find(saleAd.Id);
            if (existingSaleAd == null)
                throw new KeyNotFoundException("SaleAd not found");

            if (existingSaleAd.Price != saleAd.Price)
                existingSaleAd.Price = saleAd.Price;

            _context.Sale_Ads.Update(existingSaleAd);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var saleAd = _context.Sale_Ads.Find(id);
            if (saleAd != null)
            {
                _context.Sale_Ads.Remove(saleAd);
                _context.SaveChanges();
            }
        }
    }
}
