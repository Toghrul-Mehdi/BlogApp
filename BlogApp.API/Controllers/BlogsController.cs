using BlogApp.BL.DTOs.Blog;
using BlogApp.BL.DTOs.Category;
using BlogApp.BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IBlogService _service) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Post(BlogCreateDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }


    }
}
