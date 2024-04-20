using System;

namespace WebApi.Models.Bills
{
  public class BillCreateModel
    {
        public int Payer { get; set; }
        public float Sum { get; set; }
        public string Type { get; set; }
    }
}