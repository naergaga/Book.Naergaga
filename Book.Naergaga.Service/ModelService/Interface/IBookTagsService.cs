using Book.Naergaga.Models.Common;
using Book.Naergaga.Models.Entity;
using Book.Naergaga.Service.BaseSerivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Service.ModelService.Interface
{
    public interface IBookTagsService : IEntityService<BookTags>
    {
        List<BookTags> GetListFull<TKey>(PageOption option, Expression<Func<BookTags, bool>> where, Expression<Func<BookTags, TKey>> order);
        int CountTag(int id);
    }
}
