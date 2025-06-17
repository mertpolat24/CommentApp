using CommentApp_Cores.Enums;
using CommentApp_Cores.Models;
using CommentApp_Repositories.Contexts;
using CommentApp_Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApp_Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly Contexts.AppDbContext _context;
        

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Category entity)
        {
            _context.Categories.Add(entity);
            Save();
        }

        public void Delete(Category entity)
        {
            _context.Categories.Remove(entity);
            Save();
        }

        public Category FindById(int id)
        {
            return _context.Categories.Find(id);
        }

        public IQueryable<Category> FindByStatus(Status status)
        {
            var cat =  _context.Categories.Where(c => c.Status == status);
            return cat;
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category entity)
        {
            _context.Categories.Update(entity);
            Save();
        }
    }
}
