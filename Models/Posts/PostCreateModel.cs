using System;

namespace WebApi.Models.Posts
{
  public class PostCreateModel
    {
        public string Title { get; set;}
        public string Content { get; set; }
        public int Author { get; set; }
    }
}