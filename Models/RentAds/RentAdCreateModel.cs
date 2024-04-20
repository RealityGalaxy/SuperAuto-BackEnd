using System;

namespace WebApi.Models.RentAds
{
  public class RentAdCreateModel
    {
        public int Days { get; set; }
        public int Price { get; set; }
        public int Deposit { get; set; }
        public string Term { get; set; }
        public int Car { get; set; }
        public int Author { get; set; }
    }
}