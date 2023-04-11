using ApiTestProject.Data;
using ApiTestProject.Dtos.RequestDto;
using ApiTestProject.Interfaces;
using ApiTestProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace ApiTestProject.Repository
{
    public class CategoryRepository :  ICategoryRepository   
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context) 
        {
            _context = context;
        }
        public async Task<List<Category>> GetCategories()
        {
           var list = await _context.Categories.ToListAsync();    
           return list;          
        }
        public async Task<Category> GetCategory(int id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
            return category;
        }
        public async Task<ICollection<BlogPost>> GetBlogPosts()
        {
            var blogPost = await _context.Posts.OrderBy(x => x.Id).ToListAsync();

            return blogPost;
        }
        public async Task<bool> DeleteCategory(int id)
        {   
            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (category != null)
            {
            _context.Categories.Remove(category);
            _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
        public bool isCategoryExist(int id)
        {
            return false;
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }
        public bool Save()  
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
