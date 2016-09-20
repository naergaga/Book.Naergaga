using Book.Naergaga.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.ViewModel
{
    public class EBookViewModel
    {
        public int Id { get; set; }
        public int authorId { get; set; }
        public int CategoryId { get; set; }
        [DisplayName("书名")]
        public string Name { get; set; }
        [DisplayName("上传日期")]
        public DateTime PostTime { get; set; }
        [DisplayName("简介")]
        public string Description { get; set; }
        [DisplayName("作者")]
        public string AuthorName { get; set; }
        [DisplayName("大小")]
        public long FileSize { get; set; }
    }
}
