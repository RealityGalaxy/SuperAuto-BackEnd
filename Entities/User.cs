using System;

namespace WebApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public decimal Balance { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
    }
}