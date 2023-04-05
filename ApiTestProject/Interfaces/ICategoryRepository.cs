using ApiTestProject.Models;

namespace ApiTestProject.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetCategories();
        public Task<Category> GetCategory(int id);

      //  public Task<Category> CreateCategory();

        public Task<ICollection<BlogPost>> GetBlogPosts();

        public Task<bool> DeleteCategory(int id);
        bool isCategoryExist(int id);
    }
}
