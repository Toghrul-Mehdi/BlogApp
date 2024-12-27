using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Context
{
    public class BlogAppDBContext : DbContext
    {
        public BlogAppDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
