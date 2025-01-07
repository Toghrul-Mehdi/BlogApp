using BlogApp.Core.Entities;
using BlogApp.Core.Repositories.BlogRepository;
using BlogApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories
{
    public class BlogRepository : GenericRepository<Blog> , IBlogRepository
    {
        public BlogRepository(BlogAppDBContext _context) : base(_context)
        {
        }
    }
}
