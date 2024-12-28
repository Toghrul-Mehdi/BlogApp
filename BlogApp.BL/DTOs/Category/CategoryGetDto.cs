using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.DTOs.Category
{
    public class CategoryGetDto
    {
        public int Id  { get; set; }
        public string CategoryName { get; set; }
        public static implicit operator CategoryGetDto(BlogApp.Core.Entities.Category category)
        {
            return new CategoryGetDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
            };
        }
        
    }
}
