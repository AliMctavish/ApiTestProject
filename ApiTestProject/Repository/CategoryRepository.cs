using ApiTestProject.Data;
using ApiTestProject.Dtos.RequestDto;
using ApiTestProject.Interfaces;
using ApiTestProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace ApiTestProject.Repository
{
    public class CategoryRepository : ICategoryRepository   
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context) 
        {
            _context = context;
        }

        //public async Task<Category> CreateCategory(CategoryCreateDto categoryDto)
        //{
        //    var model = new Category() { }
        //    return await _context.Categories.Add();
        //}
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

            _context.Categories.Remove(category);

            var result = _context.SaveChanges();


            return true;
        }
        public bool isCategoryExist(int id)
        {
            return false;
        }

  
    }
}
