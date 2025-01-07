using BlogApp.BL.DTOs.Blog;
using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.Core.Repositories.BlogRepository;
using BlogApp.Core.Repositories.CategoryRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Implements
{
    public class BlogService(IBlogRepository _repo) : IBlogService
    {
        public async Task<int> CreateAsync(BlogCreateDto dto)
        {
            Blog blog = dto;
            await _repo.AddAsync(blog);
            await _repo.SaveAsync();
            return blog.Id;
        }

        public async Task<IEnumerable<BlogGetDto>> GetAllAsync()
        {
            return await _repo.GetAll().Select(x => new BlogGetDto
            {
                Title = x.Title,
                Content = x.Content,                
                UserId = x.UserId,
                CategoryId = x.CategoryId,
            }).ToListAsync();
        }
    }
}
