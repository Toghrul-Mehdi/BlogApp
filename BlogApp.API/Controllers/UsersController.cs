using BlogApp.BL.DTOs.Category;
using BlogApp.BL.DTOs.User;
using BlogApp.BL.Exceptions;
using BlogApp.BL.Helpers;
using BlogApp.BL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService _service) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Post(UserCreateDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            try
            {
                return Ok(await _service.LoginAsync(dto));
            }
            catch (Exception ex)
            {
                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        Message = bEx.ErrorMessage
                    });
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        
        
    }
}
