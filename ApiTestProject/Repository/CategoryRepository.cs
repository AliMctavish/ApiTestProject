using ApiTestProject.Data;
using ApiTestProject.Dtos.RequestDto;
using ApiTestProject.Interfaces;
using ApiTestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTestProject.Repository
{
    public class CategoryRepository : ICategoryRepository   
    {
        DataContext _context;
        public CategoryRepository(DataContext context) 
        {
            _context = context;
        }

        //public async Task<Category> CreateCategory(CategoryCreateDto categoryDto)
        //{
        //    var model = new Category() { }
        //    return await _context.Categories.Add();
        //}
        public async Task<ICollection<Category>> GetCategories()
        {
            return await _context.Categories.OrderBy(x => x.Id).ToListAsync();
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
        public async Task<Category> DeleteCategory(int id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);

            return category;
        }
        public bool isCategoryExist(int id)
        {
            return false;
        }
    }
}
