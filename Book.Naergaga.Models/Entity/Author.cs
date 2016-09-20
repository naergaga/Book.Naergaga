using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.Entity
{
    public class Author
    {
        public int Id { get; set; }
        [DisplayName("作者")]
        public string Name { get; set; }
        public string RealName { get; set; } //private
        public string Description { get; set; }

        public virtual List<EBook> Books { get; set; }
        //img
    }
}
