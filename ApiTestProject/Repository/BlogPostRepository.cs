using ApiTestProject.Data;
using ApiTestProject.Interfaces;
using ApiTestProject.Models;

namespace ApiTestProject.Repository
{
    public class BlogPostRepository: IBlogPostRepository
    {
        DataContext _context;
        BlogPostRepository(DataContext context)
        {
            _context = context;
        }


        public ICollection<BlogPost> GetBlogPosts()
        {
            return _context.BlogPosts.OrderBy(x => x.Id).ToList();
        }
    }
}
