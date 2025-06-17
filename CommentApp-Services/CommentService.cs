using AutoMapper;
using CommentApp_Cores.Enums;
using CommentApp_Cores.Models;
using CommentApp_Repositories.Contracts;
using CommentApp_Services.Contracts;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CommentApp_Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository CommentManager;
        public CommentService(ICommentRepository app)
        {
            CommentManager = app;
        }

        public void CreateComment(Comment comment)
        {
            CommentManager.Create(comment);
            CommentManager.Save();
        }

        public void DeleteComment(int id)
        {
           var com = CommentManager.FindById(id);
        }

        public IQueryable<Comment> FindCommentByStatus(Status status)
        {
            var com = (IQueryable<Comment>)CommentManager.FindByStatus(status);
            return com;
        }

        public Comment GetCommentById(int id)
        {
            var com = CommentManager.FindById(id);
            return com;
        }

        public void UpdateComment(Comment comment)
        {
            var com = CommentManager.FindById(comment.Id);
            com.CommentContent = comment.CommentContent;
            com.Status = comment.Status;
            com.Name = comment.Name;
            com.Title = comment.Title;
            com.Point = comment.Point;
            com.Category = comment.Category;
            CommentManager.Save();
        }

        public IQueryable<Comment> GetAllComments()
        {
            return CommentManager.GetAll().Include(c => c.Category);
        }
    }
}
