using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.Entity
{
    public class BookTags
    {
        [Key,Column(Order =0)]
        public int BookId { get; set; }
        [Key,Column(Order =1)]
        public int TagId { get; set; }

        public virtual EBook Book { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
