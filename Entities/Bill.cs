using System;

namespace WebApi.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public int Payer { get; set; }
        public float Sum { get; set; }
        public string Type { get; set; }
    }
}
