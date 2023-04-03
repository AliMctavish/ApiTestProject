using ApiTestProject.Data;
using ApiTestProject.Interfaces;
using ApiTestProject.Models;

namespace ApiTestProject.Repository
{
    public class CategoryRepository : ICategoryRepository   
    {
        DataContext _context;
        public CategoryRepository(DataContext context) 
        {
            _context = context;
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(x => x.Id).ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<BlogPost> GetBlogPosts()
        {
            return _context.BlogPosts.OrderBy(x => x.Id).ToList();
        }



        public bool isCategoryExist(int id)
        {
            return false;
        }





    }
}
