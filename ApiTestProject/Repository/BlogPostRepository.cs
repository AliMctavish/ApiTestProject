using ApiTestProject.Data;
using ApiTestProject.Interfaces;
using ApiTestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTestProject.Repository
{
    public class BlogPostRepository: IBlogPostRepository
    {
        DataContext _context;
        BlogPostRepository(DataContext context)
        {
            _context = context;
        }

    

        public async Task<ICollection<BlogPost>> GetBlogPosts()
        {
            var blogPosts = await _context.Posts.OrderBy(X => X.Id).ToListAsync();

            return blogPosts;
        }

        Task<BlogPost> IBlogPostRepository.CreateBlogPost()
        {

            return 
        }

        Task IBlogPostRepository.DeleteBlogPost(int id)
        {
            throw new NotImplementedException();
        }

        Task<BlogPost> IBlogPostRepository.GetBlogPost(int id)
        {
            throw new NotImplementedException();
        }


        bool IBlogPostRepository.isBlogPostExist(int id)
        {
            throw new NotImplementedException();
        }

        Task<BlogPost> IBlogPostRepository.UpdateBlogPost(int id)
        {
            throw new NotImplementedException();
        }
    }
}
