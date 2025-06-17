using CommentApp_Cores.Enums;
using CommentApp_Cores.Models;
using CommentApp_Repositories.Contexts;
using CommentApp_Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CommentApp_Repositories
{
    public class CommentRepository : ICommentRepository
    {
        protected readonly Contexts.AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            Save();
        }

        public void Delete(Comment entity)
        {
            _context.Comments.Remove(entity);
            Save();
        }

        public Comment FindById(int id)
        {
            return _context.Comments.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
            Save();
        }

        IQueryable<Comment> ICommentRepository.FindByStatus(Status status)
        {
            var com = _context.Comments.Where(c => c.Status == status);
            return com;
        }

        IQueryable<Comment> ICommentRepository.GetAll()
        {
            var com = _context.Comments;
            if (com is null)
                throw new Exception("Comment is null");
            return com.AsQueryable();
        }
    }
}
