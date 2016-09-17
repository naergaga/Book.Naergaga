using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.ViewModel
{
    public class TagViewModel
    {
        [Display(Name="ID")]
        public int Id { get; set; }
        [Display(Name = "Text")]
        public string Name { get; set; }

        public int Count { get; set; }
    }
}
