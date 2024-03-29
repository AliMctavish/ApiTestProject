﻿using System;
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
using Microsoft.AspNetCore.Authorization;

namespace ApiTestProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {

        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;


        public BlogPostsController(IBlogPostRepository blogPostRepository, IMapper mapper , ILoggerManager logger) 
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/BlogPosts
        //[Authorize]
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
            var response = _mapper.Map<BlogPostDto>(blogPost);
            if (blogPost == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateBlogPost(CreateBlogPostDto blogPostDto)
        {
            if (blogPostDto == null)
            {
                BadRequest(ModelState);
            }

            var blogPost = _blogPostRepository.GetBlogPosts().Result.Where(x => x.title.Trim().ToUpper() == blogPostDto.title.TrimEnd().ToUpper()).FirstOrDefault();

            if (blogPost != null)
            {
                _logger.LogInfo("someone is trying to create an object with the same name ! ");
                return BadRequest("this post is already exist with the same name");
            }

            var blogPostMapped = _mapper.Map<BlogPost>(blogPostDto);

            if (!_blogPostRepository.CreateBlogPost(blogPostMapped))
            {
                ModelState.AddModelError("status", "something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("تم انشاء منتج جديد");
        }
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateBlogPost(BlogPostDto blogPostDto)
        {
            var blogPostMapper =  _mapper.Map<BlogPost>(blogPostDto);
            
            _blogPostRepository.UpdateBlogPost(blogPostMapper);
            _logger.LogWarn("the user is updating the post");
            return Ok("تم التعديل على المنتج بنجاح");
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            if(id == null)
                return NotFound();

            var blogPost = await _blogPostRepository.DeleteBlogPost(id);

            if (blogPost == false)
                return BadRequest("no such a product exist in database");

            return Ok("product deleted");
        }
    }
}
