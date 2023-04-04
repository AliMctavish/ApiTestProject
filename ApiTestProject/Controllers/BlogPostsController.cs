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

namespace ApiTestProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly DataContext _context;

        public BlogPostsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BlogPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetBlogPosts()
        {
          if (_context.Posts == null)
          {
              return BadRequest("empty");
          }
          var blogPosts = await _context.Posts.ToListAsync();
            Console.WriteLine(blogPosts);
            return blogPosts;
        }

        // GET: api/BlogPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetBlogPost(int id)
        {
          if (_context.Posts == null)
          {
              return NotFound();
          }
            var blogPost = await _context.Posts.FindAsync(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return blogPost;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPost(int id, BlogPost blogPost)
        {
            if (id != blogPost.Id)
            {
                return BadRequest();
            }

            _context.Entry(blogPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlogPost>> PostBlogPost(BlogPostDto blogPost)
        {
          if (_context.Posts == null)
          {
              return Problem("Entity set 'DataContext.Posts'  is null.");
          }
            var model = new BlogPost() { title = blogPost.title, description = blogPost.description , CategoryId = blogPost.CategoryId};

            _context.Posts.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogPost", new { id = model.Id }, blogPost);
        }

        // DELETE: api/BlogPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var blogPost = await _context.Posts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(blogPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogPostExists(int id)
        {
            return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
