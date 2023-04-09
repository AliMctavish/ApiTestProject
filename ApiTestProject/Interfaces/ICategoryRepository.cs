using ApiTestProject.Models;

namespace ApiTestProject.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<ICollection<BlogPost>> GetBlogPosts();
        Task<bool> DeleteCategory(int id);
        bool isCategoryExist(int id);
        bool CreateCategory(Category category);
        bool Save();
    }
}
