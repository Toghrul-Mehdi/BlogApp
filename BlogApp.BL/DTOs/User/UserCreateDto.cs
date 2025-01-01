using BlogApp.Core.Entities;
using BlogApp.BL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.DTOs.User
{
    public class UserCreateDto
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public static implicit operator BlogApp.Core.Entities.User(UserCreateDto dto)
        {
            BlogApp.Core.Entities.User user = new BlogApp.Core.Entities.User
            {
                UserName = dto.UserName,
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = BlogApp.BL.Helpers.HashHelper.HashPassword(dto.Password),
            };
            return user;
        }

    }
}
