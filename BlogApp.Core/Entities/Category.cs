using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; } = null!;        
        public IEnumerable<Blog> Blogs { get; set; }
    }
}
