using Book.Naergaga.Models.Common;
using Book.Naergaga.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Book.Naergaga.Models.PublicView
{
    public class SearchViewModel<T>
    {
        public List<T> List { get; set; }
        public string Keyword { get; set; }
        public PageOption Option { get; set; }
        public string Mode { get; set; }
        public RouteValueDictionary RouteData { get; set; }
    }
}
