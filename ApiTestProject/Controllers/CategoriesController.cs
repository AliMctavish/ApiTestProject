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
using AutoMapper;
using ApiTestProject.Repository;
using Microsoft.AspNetCore.Identity;
using ApiTestProject.Interfaces;
using System.Diagnostics;

namespace ApiTestProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        // GET: api/Categories
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            var mapperResult = _mapper.Map<List<CategoryCreateDto>>(categories);
            if (!categories.Any())
            {
                return BadRequest("empty");
            }
            return Ok(mapperResult);
        }
        // GET: api/Categories/5
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = _categoryRepository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var deleteCategory = await _categoryRepository.DeleteCategory(id);
            if(deleteCategory)
            return Ok(deleteCategory);

            return BadRequest("not deleted");
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest(ModelState);

            var category = _categoryRepository.GetCategories().Result.Where(x => x.Name.Trim().ToUpper() == categoryDto.name.TrimEnd().ToUpper()).FirstOrDefault();

            if (category != null)
                return BadRequest("this category already exist");

            var mappingData = _mapper.Map<Category>(categoryDto);

            _categoryRepository.CreateCategory(mappingData);

            Debug.WriteLine(mappingData);

            return Ok("You just created a category ! ");
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCategory(int id, Category category)
        //{
        //    if (id != category.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(category).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       // [HttpPost]
        //public IActionResult PostCategory(CategoryCreateDto category)
        //{
        //  if (_categoryRepository.GetCategories() == null)
        //  {
        //      return Problem("Entity set 'DataContext.Categories'  is null.");
        //  }

        //    var model = _mapper.Map<Category>(category);

        //    _categoryRepository.GetCategories().Add(model);

        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCategory", new { id = model.Id }, category);
        //}

        // DELETE: api/Categories/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    if (_context.Categories == null)
        //    {
        //        return NotFound();
        //    }
        //    var category = await _context.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Categories.Remove(category);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CategoryExists(int id)
        //{
        //    return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
