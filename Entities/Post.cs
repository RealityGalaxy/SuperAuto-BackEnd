using System;

namespace WebApi.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Content { get; set; }
        public DateTime Edit_Date { get; set; }
        public int Author { get; set; }
    }
}
