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
    public interface IBookService : IEntityService<EBook>
    {
        int CountBookInCategory(int id);
        int CountBookInAuthor(int id);
        List<EBook> GetPageFull<TKey>(PageOption option, Expression<Func<EBook, TKey>> expression);
    }
}
