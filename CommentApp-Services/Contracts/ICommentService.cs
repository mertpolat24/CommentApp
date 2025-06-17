using CommentApp_Cores.Enums;
using CommentApp_Cores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApp_Services.Contracts
{
    public interface ICommentService
    {
        IQueryable<Comment> GetAllComments();
        Comment GetCommentById(int id);
        IQueryable<Comment> FindCommentByStatus(Status status);
        void CreateComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int id);
    }
}
