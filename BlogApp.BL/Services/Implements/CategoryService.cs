using BlogApp.BL.DTOs.Category;
using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.Core.Repositories.CategoryRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Implements
{
    public class CategoryService(ICategoryRepository _repo) : ICategoryService
    {
        public async Task<int> CreateAsync(CategoryCreateDto dto)
        {
            Category cat = dto;
            await _repo.AddAsync(cat);
            await _repo.SaveAsync();
            return cat.Id;
        }

        public async Task<IEnumerable<CategoryGetDto>> GetAllAsync()
        {
            return await _repo.GetAll().Select(x => new CategoryGetDto
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
            }).ToListAsync();
        }
    }
}
