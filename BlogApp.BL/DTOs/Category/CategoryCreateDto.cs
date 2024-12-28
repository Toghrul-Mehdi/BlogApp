using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.DTOs.Category
{
    public class CategoryCreateDto
    {
        public string CategoryName { get; set; }
        public static implicit operator BlogApp.Core.Entities.Category(CategoryCreateDto dto)
        {
            BlogApp.Core.Entities.Category category = new BlogApp.Core.Entities.Category
            {
                CategoryName = dto.CategoryName,
            };
            return category;
        }
    }
}
