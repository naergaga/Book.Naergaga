using Book.Naergaga.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.AdminView
{
    public class IndexViewModel<T>
    {
        public List<T> List { get; set; }
        public PageOption Option { get; set; }
    }
}
