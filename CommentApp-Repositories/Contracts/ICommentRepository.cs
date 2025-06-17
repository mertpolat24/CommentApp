using CommentApp_Cores.Enums;
using CommentApp_Cores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApp_Repositories.Contracts
{
    public interface ICommentRepository
    {
        IQueryable<Comment> GetAll();
        Comment FindById(int id);
        IQueryable<Comment> FindByStatus(Status status);
        void Create(Comment entity);
        void Update(Comment entity);
        void Delete(Comment entity);
        void Save();
    }
}
