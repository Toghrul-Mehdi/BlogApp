using BlogApp.BL.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.DTOs.User
{
    public class UserGetDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public static implicit operator UserGetDto(BlogApp.Core.Entities.User user)
        {
            return new UserGetDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                Email =user.Email,
                Password =user.Password
            };
        }
    }
}
