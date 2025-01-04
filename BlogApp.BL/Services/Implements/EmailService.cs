using BlogApp.BL.Helpers;
using BlogApp.BL.Services.Interfaces;
using BlogApp.DAL.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.BL.Services.Implements
{
    public class EmailService(BlogAppDBContext _context, IConfiguration _configuration, IOptions<SmtpOptions> _options) : IEmailService
    {
        readonly SmtpOptions _smtp = _options.Value;
        public async Task<string> GenerateEmailVerificationToken(string email)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Email, email)
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: credentials
            );

            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }

        public Task<string> SendVerificationEmail(string email)
        {

            var token = GenerateEmailVerificationToken(email).Result;
            var verificationUrl = $"http://localhost:5011/verify-email?token={token}";


            SmtpClient smtp = new SmtpClient
            {
                Host = _smtp.Host,
                Port = _smtp.Port,
                EnableSsl = true,
                Credentials = new NetworkCredential(_smtp.Username, _smtp.Password)
            };


            MailMessage msg = new MailMessage
            {
                From = new MailAddress(_smtp.Username, "Togrul Mehdiyev CodeAcademy"),
                Subject = "E-posta Doğrulama",
                Body = $"<p>Hesabınızı tesdiqlemek ucun <a href='{verificationUrl}'>bu linke</a> klikleyin.</p>",
                IsBodyHtml = true
            };
            msg.To.Add(email);


            smtp.Send(msg);

            return Task.FromResult("Email ugurla gonderildi.");


        }


        public async Task VerifyEmail(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var claims = handler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"],
                IssuerSigningKey = key
            },out var validatedToken);

            var email = claims.FindFirst(ClaimTypes.Email)?.Value;

            if(email != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
                if(user != null)
                {
                    user.IsEmailConfirmed = true;
                    user.Role = 1;
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
