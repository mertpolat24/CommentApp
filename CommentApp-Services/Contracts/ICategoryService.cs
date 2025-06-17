using CommentApp_Cores.Enums;
using CommentApp_Cores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApp_Services.Contracts
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAllCategories();
        Category FindCategoryById(int id);
        IQueryable<Category> FindCategoryByStatus(Status status);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
