using ApiTestProject.Data;
using ApiTestProject.Interfaces;
using ApiTestProject.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiTestProject.Repository
{
    public class BlogPostRepository: IBlogPostRepository
    {
        private readonly DataContext _context;
        public BlogPostRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            var blogPosts = await _context.Posts.Include(x=>x.Category).OrderBy(X => X.Id).ToListAsync();
            return blogPosts;
        }

        public  List<Category> GetCategories()
        {
            return  _context.Categories.ToList();
        }


        public async Task<BlogPost> GetBlogPost(int id)
        {
            var blogPost = await _context.Posts.FindAsync(id);
            return blogPost;
        }


        public async Task<BlogPost> CreateBlogPost()
        {
            BlogPost blogPost = new BlogPost();
            _context.SaveChangesAsync();
            return blogPost;
        }
    
        Task IBlogPostRepository.DeleteBlogPost(int id)
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
