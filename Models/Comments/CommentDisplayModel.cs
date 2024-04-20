using System;

namespace WebApi.Models.Comments
{
  public class CommentDisplayModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int Post { get; set; }
        public int AuthorId { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Edit_Date { get; set; }
    }
}