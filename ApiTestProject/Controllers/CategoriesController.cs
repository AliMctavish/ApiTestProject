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
            var mappingData =  _mapper.Map<Category>(categoryDto);
            _categoryRepository.CreateCategory(mappingData);
            return Ok("You just created a category !");
        }



        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateCategory(CategoryUpdateDto updateDto)
        {
            var mappedCategory = _mapper.Map<Category>(updateDto);

            _categoryRepository.UpdateCategory(mappedCategory);

            return Ok();
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var deleteCategory = await _categoryRepository.DeleteCategory(id);
            if (deleteCategory)
                return Ok(deleteCategory);

            return BadRequest("not deleted");
        }
    }
}
