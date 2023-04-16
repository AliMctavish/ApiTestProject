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
            return await _context.Posts.Include(x=>x.Category).OrderBy(X => X.Id).ToListAsync();
        }

        public  List<Category> GetCategories()
        {
            return  _context.Categories.ToList();
        }

        public async Task<BlogPost> GetBlogPost(int id)
        {
            var blogPost = await _context.Posts.Include(x=>x.Category).SingleOrDefaultAsync(x=>x.Id == id);
            return blogPost;
        }

        public bool CreateBlogPost(BlogPost blogPost)
        {
            var categoryExist = _context.Categories.Where(x => x.Id == blogPost.CategoryId);
            
            if (!categoryExist.Any())
                return false;

            _context.Add(blogPost);
            return Save();
        }
        public async Task<bool> DeleteBlogPost(int id)
        {
            var blogPost = await _context.Posts.Where(x => x.Id == id).SingleOrDefaultAsync();

            if(blogPost != null)
            {
            _context.Posts.Remove(blogPost);
            return true;
            }

            return  false;
        }
        public bool UpdateBlogPost(BlogPost blogPost)
        {
            _context.Update(blogPost);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
