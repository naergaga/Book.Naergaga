using Book.Naergaga.Models.Entity;
using Book.Naergaga.Models.EntityContext;
using Book.Naergaga.Service.BaseSerivces;
using Book.Naergaga.Service.ModelService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Service.ModelService.Implanment
{
    public class BookTagsService : EntityService<BookTags>, IBookTagsService
    {

        public BookTagsService(DataContext context) : base(context) { }

        public int CountTag(int id)
        {
            return _dbset.Where(t => t.TagId == id).Count();
        }

    }
}
