using ApiTestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext :DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            
        }


        DbSet<BlogPost>? blogPosts { get; set; }
        DbSet<Category>? categories { get; set; }
        DbSet<User>? users { get; set; }
    }
}