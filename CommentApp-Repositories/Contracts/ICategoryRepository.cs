using CommentApp_Cores.Enums;
using CommentApp_Cores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApp_Repositories.Contracts
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll();
        Category FindById(int id);
        IQueryable<Category> FindByStatus(Status status);
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        void Save();
    }
}
