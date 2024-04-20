using System;

namespace WebApi.Models.SaleAds
{
  public class SaleAdCreateModel
    {
        public int Days { get; set; }
        public int Price { get; set; }
        public int Car { get; set; }
        public int Author { get; set; }
    }
}