using ApiTestProject.Models;

namespace ApiTestProject.Interfaces
{
    public interface IBlogPostRepository
    {
        public  Task<ICollection<BlogPost>> GetBlogPosts();
        public Task<BlogPost> GetBlogPost(int id);
       // public Task<BlogPost> CreateBlogPost();

        public Task<BlogPost> UpdateBlogPost(int id);

        public Task DeleteBlogPost(int id);

        public bool isBlogPostExist(int id);
    }
}
