using Book.Naergaga.Models.Entity;
using Book.Naergaga.Models.EntityContext;
using Book.Naergaga.Service.BaseSerivces;
using Book.Naergaga.Service.ModelService.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Naergaga.Models.Common;
using System.Linq.Expressions;

namespace Book.Naergaga.Service.ModelService.Implanment
{
    public class BookTagsService : EntityService<BookTags>, IBookTagsService
    {

        public BookTagsService(DataContext context) : base(context) { }

        public int CountTag(int bookId)
        {
            return _dbset.Where(c => c.BookId == bookId).Count();
        }

        public List<BookTags> GetListFull()
        {
            return _dbset.Include(b => b.Book).Include(b => b.Tag).ToList();
        }

        public List<BookTags> GetListFull<TKey>(PageOption option, Expression<Func<BookTags, bool>> where, Expression<Func<BookTags, TKey>> order)
        {
            return _dbset.Where(where).OrderBy(order).Include(b => b.Book).Include(b => b.Tag).ToList();
        }
    }
}
