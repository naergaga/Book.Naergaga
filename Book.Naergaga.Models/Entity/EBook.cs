using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.Entity
{
    public class EBook
    {
        public int Id { get; set; }
        public int authorId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime PostTime { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public long FileSize { get; set; }

        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
        //img
    }
}
