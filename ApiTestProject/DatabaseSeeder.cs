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
                var categories = new List<Category>()
                {
                    new Category { Name = "قسم السياسة", Id = 1 },
                    new Category { Name = "قسم الرياضة", Id = 2 },
                    new Category { Name = "قسم العلوم", Id = 3 },
                    new Category { Name = "قسم التاريخ", Id = 4 },
                };

                var users = new List<User>()
                {
                    new User {Name = "admin" , age = 25 ,country ="iraq" , Id = 1},
                    new User {Name = "user" , age = 23 , country="life" , Id = 2},
                };

                var blogPosts = new List<BlogPost>()
                {
                new BlogPost{ Id =1,CategoryId = 1 , description="كل ما تحتاجه حول الحياة" , title="الموت المسالم" , CreatedDate = DateTime.Now , Category = categories.Where(x=>x.Id == 1).First() },
                new BlogPost{ Id=1, CategoryId = 2 , description="كل ما تحتاجه حول الموت" , title="الحياة المسالمة" , CreatedDate = DateTime.Now , Category = categories.Where(x=>x.Id == 2).First() },
                };
                _context.AddRange(categories);
            _context.SaveChanges();
            }
        }

    }
}
