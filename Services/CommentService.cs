using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Comments;
using WebApi.Models.Posts;

namespace WebApi.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentDisplayModel> GetAll();
        Comment GetById(int id);
        Comment Create(Comment comment);
        void Update(Comment comment);
        void Delete(int id);
    }

    public class CommentService : ICommentService
    {
        private readonly DataContext _context;
        private IUserService _userService;

        public CommentService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public IEnumerable<CommentDisplayModel> GetAll()
        {
            IEnumerable<Comment> comments = new List<Comment>(_context.Comments);

            List<CommentDisplayModel> models = new List<CommentDisplayModel>();
            foreach (Comment comment in comments)
            {
                models.Add(new CommentDisplayModel()
                {
                    Id = comment.Id,
                    Post = comment.Post,
                    Creation_Date = comment.Creation_Date,
                    Content = comment.Content,
                    Edit_Date = comment.Edit_Date,
                    Author = _userService.GetById(comment.Author).Username,
                    AuthorId = comment.Author
                });
            }

            return models.AsEnumerable();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

        public Comment Create(Comment comment)
        {
            comment.Creation_Date = DateTime.Now;
            comment.Edit_Date = DateTime.Now;

            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }

        public void Update(Comment comment)
        {
            var existingComment = _context.Comments.Find(comment.Id);
            if (existingComment == null)
                throw new KeyNotFoundException("Comment not found");

            // Update properties
            // Add other properties as needed
            if(comment.Content != existingComment.Content)
                existingComment.Content = comment.Content;

            existingComment.Edit_Date = DateTime.Now;

            _context.Comments.Update(existingComment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
        }
    }
}
