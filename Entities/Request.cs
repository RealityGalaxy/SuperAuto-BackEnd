using System;

namespace WebApi.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Status { get; set; }
        public int Owner { get; set; }
        public int Renter { get; set; }
        public int Car { get; set; }
    }
}
