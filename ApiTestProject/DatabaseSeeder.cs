using ApiTestProject.Data;
using ApiTestProject.Models;

namespace ApiTestProject
{
    public class DatabaseSeeder
    {
        private readonly DataContext _context;

        public DatabaseSeeder(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            if(!_context.Categories.Any())
            {
                var categories = new List<Category>();
            }
        }

    }
}
