using System;

namespace WebApi.Entities
{
    public class SaleAd
    {
        public int Id { get; set; }
        public DateTime Creation_Date { get; set; }
        public int Price { get; set; }
        public DateTime Expiry_Date { get; set; }
        public int Car { get; set; }
        public int Author { get; set; }
    }
}
