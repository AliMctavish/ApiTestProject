using ApiTestProject.Models;

namespace ApiTestProject.Interfaces
{
    public interface IBlogPostRepository
    {
       public  ICollection<BlogPost> GetBlogPosts();
    }
}
