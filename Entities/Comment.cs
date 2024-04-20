using System;

namespace WebApi.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Content { get; set; }
        public DateTime Edit_Date { get; set; }
        public int Post { get; set; }
        public int Author { get; set; }
    }
}
