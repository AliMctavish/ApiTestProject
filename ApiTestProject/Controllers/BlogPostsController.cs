using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTestProject.Data;
using ApiTestProject.Models;
using ApiTestProject.Dtos.RequestDto;
using System.Diagnostics;
using ApiTestProject.Repository;
using AutoMapper;
using Microsoft.OpenApi.Writers;
using ApiTestProject.Interfaces;

namespace ApiTestProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {

        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;
       

        public BlogPostsController(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }

        // GET: api/BlogPosts
        [HttpGet]
        public async Task<IActionResult> GetBlogPosts()
        {
          var blogPosts = await _blogPostRepository.GetBlogPosts();
          var response = _mapper.Map<List<BlogPostDto>>(blogPosts);
          if (!blogPosts.Any())
          {
              return BadRequest("empty");
          }
          return Ok(response);
        }

        // GET: api/BlogPosts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPost(int id)
        {
          var blogPost = await _blogPostRepository.GetBlogPost(id);
          if (blogPost == null)
          {
              return NotFound();
          }
          return Ok(blogPost);
        }
        //[HttpPost]
        //public IActionResult CreateBlogPost(BlogPostDto blogPost)
        //{
        //    bool isIn = false;
        //    var categories = _blogPostRepository.GetCategories();
        //    foreach (var category in categories)
        //    {
        //        if (category.Id == blogPost.CategoryId)
        //        {
        //            isIn = true;
        //            break;
        //        }
        //    }
        //    if (!isIn)
        //    {
        //      return Problem("Entity set 'DataContext.category with id'  is null.");
        //    }
        //    var model  = _mapper.Map<BlogPost>(blogPost);

            

        //    return Ok(model);
        //}

        // DELETE: api/BlogPosts/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBlogPost(int id)
        //{
        //    if (_context.Posts == null)
        //    {
        //        return NotFound();
        //    }
        //    var blogPost = await _context.Posts.FindAsync(id);
        //    if (blogPost == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Posts.Remove(blogPost);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool BlogPostExists(int id)
        //{
        //    return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
