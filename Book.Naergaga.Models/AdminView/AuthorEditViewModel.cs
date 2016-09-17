using Book.Naergaga.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.AdminView
{
    public class AuthorEditViewModel
    {
        public Author Author { get; set; }
        public bool IsCreate { get; set; }
    }
}
