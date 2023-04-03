using ApiTestProject.Models;

namespace ApiTestProject.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);

        ICollection<BlogPost> GetBlogPosts();

        bool isCategoryExist(int id);
    }
}
