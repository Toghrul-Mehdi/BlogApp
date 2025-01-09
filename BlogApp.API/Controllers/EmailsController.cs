using BlogApp.BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController(IEmailService _emailservice) : ControllerBase
    {
        [HttpPost("Send-Email")]
        public async Task<IActionResult> SendVerificationEmail(string email)
        {            
            return Ok(await _emailservice.SendVerificationEmailAsync(email));
        }

        [HttpPost("Verify-Email")]
        public async Task<IActionResult> VerifyEmail(string email,int code)
        {
           await _emailservice.VerifyEmailAsync(email,code);
            return Ok("Email Verified");
        }
    }
}
