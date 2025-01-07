using BlogApp.BL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.DTOs.Blog
{
    public class BlogGetDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public static implicit operator BlogGetDto(BlogApp.Core.Entities.Blog blog)
        {
            return new BlogGetDto
            {
                Title = blog.Title,
                Content = blog.Content,
                CategoryId = blog.CategoryId,
                UserId = blog.UserId
            };
        }
    }
}
