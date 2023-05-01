using ApiTestProject.Data;
using Microsoft.EntityFrameworkCore;
using ApiTestProject.Controllers;
using ApiTestProject.Interfaces;
using ApiTestProject.Repository;
using ApiTestProject;
using ApiTestProject.Models;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using ApiTestProject.Services;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSwaggerGen();
//builder.Services.AddIdentityCore<User>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
ServiceExtentions.ConfigureLoggerService(builder.Services);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseStaticFiles();

app.Use(async (context, next) =>
{
    Console.WriteLine($"Logic before executing the next delegate in the Use method");
    await next.Invoke();
});

app.UseHttpsRedirection();

app.UseRouting();


app.UseAuthorization();


app.UseAuthentication();

app.MapControllers();



app.Run();
