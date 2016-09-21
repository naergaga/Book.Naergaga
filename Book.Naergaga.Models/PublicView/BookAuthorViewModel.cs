using Book.Naergaga.Models.Common;
using Book.Naergaga.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.PublicView
{
    public class BookAuthorViewModel
    {
        public Author Author { get; set; }
        public IEnumerable<EBook> Books { get; set; }
        public PageOption Option { get; set; }
    }
}
