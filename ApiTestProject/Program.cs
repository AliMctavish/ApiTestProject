using ApiTestProject.Data;
using Microsoft.EntityFrameworkCore;
using ApiTestProject.Controllers;
using ApiTestProject.Interfaces;
using ApiTestProject.Repository;
using ApiTestProject;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSwaggerGen();
//builder.Services.AddTransient<DatabaseSeeder>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();

var app = builder.Build();

//if (args.Length == 1 && args[0].ToLower() == "seeddata")
//    SeedData(app);

//void SeedData(IHost app)
//{
//    var scopredFactory = app.Services.GetService<IServiceScopeFactory>();
//    using (var scope = scopredFactory.CreateScope())
//    {
//        var service = scope.ServiceProvider.GetService<DatabaseSeeder>();
//        service.SeedDataContext();
//    }
//}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
