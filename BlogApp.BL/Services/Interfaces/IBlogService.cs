using BlogApp.BL.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interfaces
{
    public interface IBlogService
    {
        Task<int> CreateAsync(BlogCreateDto dto);
        Task<IEnumerable<BlogGetDto>> GetAllAsync();
    }
}
