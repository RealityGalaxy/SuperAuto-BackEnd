using System;

namespace WebApi.Models.Comments
{
  public class CommentCreateModel
    {
        public string Content { get; set; }
        public int Post { get; set; }
        public int Author { get; set; }
    }
}