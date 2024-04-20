using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Posts;

namespace WebApi.Services
{
    public interface IPostService
    {
        IEnumerable<PostDisplayModel> GetAll();
        PostDisplayModel GetById(int id);
        Post Create(Post post);
        void Update(Post post);
        void Delete(int id);
    }

    public class PostService : IPostService
    {
        private readonly DataContext _context;
        private IUserService _userService;

        public PostService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public IEnumerable<PostDisplayModel> GetAll()
        {
            IEnumerable<Post> posts = new List<Post>(_context.Posts);

            List<PostDisplayModel> models = new List<PostDisplayModel>();
            foreach (Post post in posts)
            {
                models.Add(new PostDisplayModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Creation_Date = post.Creation_Date,
                    Content = post.Content,
                    Edit_Date = post.Edit_Date,
                    Author = _userService.GetById(post.Author).Username,
                    AuthorId = post.Author
                });
            }

            return models.AsEnumerable();
        }

        public PostDisplayModel GetById(int id)
        {
            Post post = _context.Posts.Find(id);
            if (post == null)
                throw new KeyNotFoundException("Post not found");
            PostDisplayModel model = new PostDisplayModel
            {
                Id = post.Id,
                Title = post.Title,
                Creation_Date = post.Creation_Date,
                Content = post.Content,
                Edit_Date = post.Edit_Date,
                Author = _userService.GetById(post.Author).Username,
                AuthorId = post.Author
            };

            return model;
        }

        public Post Create(Post post)
        {
            post.Creation_Date = DateTime.Now;
            post.Edit_Date = DateTime.Now;

            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }

        public void Update(Post post)
        {
            var existingPost = _context.Posts.Find(post.Id);
            if (existingPost == null)
                throw new KeyNotFoundException("Post not found");

            if(post.Content != existingPost.Content)
                existingPost.Content = post.Content;

            if(post.Title != existingPost.Title)
                existingPost.Title = post.Title;

            post.Edit_Date = DateTime.Now;

            _context.Posts.Update(existingPost);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = _context.Posts.Find(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }
    }
}
