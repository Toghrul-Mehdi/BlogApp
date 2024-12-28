using BlogApp.Core.Entities;
using BlogApp.Core.Repositories.CategoryRepository;
using BlogApp.Core.Repositories.UserRepository;
using BlogApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BlogAppDBContext _context) : base(_context)
        {
        }
    }
}
