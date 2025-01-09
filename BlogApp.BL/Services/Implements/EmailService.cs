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
using BlogApp.BL.Exceptions.Common;
using Microsoft.Extensions.Caching.Memory;
using BlogApp.Core.Entities;
using BlogApp.Core.Enums;

namespace BlogApp.BL.Services.Implements
{
    public class EmailService(BlogAppDBContext _context, IConfiguration _configuration, IOptions<SmtpOptions> _options,IMemoryCache _cache) : IEmailService
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

        public async Task<string> SendVerificationEmailAsync(string email)
        {
            
            if (_cache.TryGetValue(email, out var _))
            {
                throw new ExistException("Email artiq gonderilib");
            }
            var data = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (data==null)
                throw new NotFoundException<User>();

            Random random = new Random();   
            int code = random.Next(100000,999999);



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
                Subject = "Email Tesdiqleme",
                Body = $"<p>Hesabınızı təsdiq etmək üçün aşağıdaki kodu istifade edin:</p>" + $"<p><strong>{code}</strong></p>",
                IsBodyHtml = true
            };
            msg.To.Add(email);
            smtp.Send(msg);   
            _cache.Set(email, code,TimeSpan.FromMinutes(3));
            return "Email gonderildi.";
        }        

        public async Task<bool> VerifyEmailAsync(string email, int code)
        {
            if (!_cache.TryGetValue(email, out int result))
                throw new NotFoundException("Kod gondermemisik");
            if (result != code)
                throw new Exception("Code invalid exception");
            var user = await _context.Users.Where(x=>x.Email==email).FirstOrDefaultAsync();
            user!.IsEmailConfirmed = true;
            user.Role = (int)Roles.Publisher;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
