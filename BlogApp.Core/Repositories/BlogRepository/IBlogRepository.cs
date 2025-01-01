using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Repositories.BlogRepository
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
    }
}
