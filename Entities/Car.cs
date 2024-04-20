using System;

namespace WebApi.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string License_Plate { get; set; }
        public int Creation_Date { get; set; }
        public int Mileage { get; set; }
        public int Seats { get; set; }
        public string Description { get; set; }
        public string Transmission { get; set; }
        public string Fuel_Type { get; set; }
        public string Body_Type { get; set; }
        public string State { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Owner { get; set; }
        public string Image { get; set; }
    }
}
