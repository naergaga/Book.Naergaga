using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.Common
{
    public class PageOption
    {
        public PageOption()
        {
            PageSize = 15;
            CurrentPage = 1;
            Asc = true;
        }

        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public bool Asc { get; set; }
    }
}
