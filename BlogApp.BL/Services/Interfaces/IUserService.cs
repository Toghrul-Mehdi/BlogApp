using BlogApp.BL.DTOs.Category;
using BlogApp.BL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserGetDto>> GetAllAsync();
        Task<int> CreateAsync(UserCreateDto dto);
        Task<string> LoginAsync(UserLoginDto dto);
    }
}
