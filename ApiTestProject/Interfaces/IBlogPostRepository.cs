using ApiTestProject.Models;

namespace ApiTestProject.Interfaces
{
    public interface IBlogPostRepository
    {
        public  Task<List<BlogPost>> GetBlogPosts();
        public Task<BlogPost> GetBlogPost(int id);
        bool UpdateBlogPost(BlogPost blogPost);
        bool  CreateBlogPost(BlogPost blogPost);
        //public bool isBlogPostExist(int id);
        
        Task<bool> DeleteBlogPost(int id);
    }
}
