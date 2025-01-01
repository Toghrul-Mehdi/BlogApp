using BlogApp.BL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.DTOs.Blog
{
    public class BlogCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public static implicit operator BlogApp.Core.Entities.Blog(BlogCreateDto dto)
        {
            BlogApp.Core.Entities.Blog blog = new BlogApp.Core.Entities.Blog
            {
                Title = dto.Title,
                Content = dto.Content,
                UserId = dto.UserId,
                CategoryId = dto.CategoryId,
            };
            return blog;
        }

    }
}
