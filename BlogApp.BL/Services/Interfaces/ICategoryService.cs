using BlogApp.BL.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryGetDto>> GetAllAsync();
        Task<int> CreateAsync(CategoryCreateDto dto);
    }
}
