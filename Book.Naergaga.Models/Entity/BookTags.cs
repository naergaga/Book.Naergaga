using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.Entity
{
    public class BookTags
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int TagId { get; set; }

        public virtual EBook Book { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
