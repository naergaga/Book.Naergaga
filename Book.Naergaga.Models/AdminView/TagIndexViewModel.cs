using Book.Naergaga.Models.Common;
using Book.Naergaga.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.AdminView
{
    public class TagIndexViewModel
    {
        public List<Tag> Tags { get; set; }
        public PageOption Option { get; set; }
    }
}
