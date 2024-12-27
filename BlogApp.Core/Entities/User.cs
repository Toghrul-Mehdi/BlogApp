using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public string Password { get; set; } = null!;
        public IEnumerable<Blog> Blogs { get; set; }
    }
}
