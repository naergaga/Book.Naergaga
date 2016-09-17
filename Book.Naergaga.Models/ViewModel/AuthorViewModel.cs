using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.ViewModel
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; } //private
        public string Description { get; set; }

    }
}
