using ApiTestProject.Models;

namespace ApiTestProject.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategories();
        public Task<Category> GetCategory(int id);

      //  public Task<Category> CreateCategory();

        public Task<ICollection<BlogPost>> GetBlogPosts();

        public Task<Category> DeleteCategory(int id);
        bool isCategoryExist(int id);
    }
}
