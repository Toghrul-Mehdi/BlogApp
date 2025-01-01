using BlogApp.BL.DTOs.Category;
using BlogApp.BL.DTOs.User;
using BlogApp.BL.Exceptions.Common;
using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.Core.Repositories.CategoryRepository;
using BlogApp.Core.Repositories.UserRepository;
using BlogApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Implements
{
    public class UserService(IUserRepository _repo,BlogAppDBContext _context) : IUserService
    {
        public async Task<int> CreateAsync(UserCreateDto dto)
        {            
            User user = dto;
            await _repo.AddAsync(user);
            await _repo.SaveAsync();
            return user.Id;
        }

        public async Task<IEnumerable<UserGetDto>> GetAllAsync()
        {
            return await _repo.GetAll().Select(x => new UserGetDto
            {
                Id = x.Id,
                UserName = x.UserName,
                FullName = x.FullName,
                Email = x.Email,
                PasswordHash = x.PasswordHash,
            }).ToListAsync();
        }

        public async Task<string> LoginAsync(UserLoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == dto.UserName);
            if (user == null)
            {
                throw new NotFoundException<User>();    
            }
            bool isPasswordValid = BlogApp.BL.Helpers.HashHelper.VerifyHashedPassword(user.PasswordHash, dto.Password);
            if (!isPasswordValid)
            {
                return "Istifadeci adi ve ya parol yanlisdir";
            }
            return "Hesaba daxil oldunuz";
        }
    }
}
