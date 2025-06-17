using AutoMapper;
using CommentApp_Cores.Enums;
using CommentApp_Cores.Models;
using CommentApp_Repositories.Contracts;
using CommentApp_Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApp_Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryService;

        public CategoryService(ICategoryRepository categoryService)
        {
            _categoryService = categoryService;
        }

        public void CreateCategory(Category category)
        {
            _categoryService.Create(category);
            _categoryService.Save();
        }

        public void DeleteCategory(int id)
        {
            var cs = _categoryService.FindById(id);
            if (cs is null)
                throw new Exception("Category Not Found");
            _categoryService.Delete(cs);
            _categoryService.Save();
        }

        public Category FindCategoryById(int id)
        {
            return _categoryService.FindById(id);
        }

        public IQueryable<Category> FindCategoryByStatus(Status status)
        {
            var cs = (IQueryable<Category>)_categoryService.FindByStatus(status);
            return cs;
        }

        public IQueryable<Category> GetAllCategories()
        {
            var cs = (IQueryable<Category>)_categoryService.GetAll();
            return cs;
        }

        public void UpdateCategory(Category category)
        {
            var cs = _categoryService.FindById(category.Id);
            cs.Name = category.Name;
            cs.Status = category.Status;
        }
    }
}
