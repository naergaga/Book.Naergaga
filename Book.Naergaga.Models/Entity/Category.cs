using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<EBook> Books { get; set; }
    }
}
