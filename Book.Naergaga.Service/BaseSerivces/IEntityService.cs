using Book.Naergaga.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Service.BaseSerivces
{
    public interface IEntityService<T,K> where T:class
    {
        bool Create(T entity);
        bool Delete(K id);
        bool Update(T entity);
        List<T> GetAll();
        int CountPage(int pageSize);
        List<T> GetPage<TKey>(PageOption option, Expression<Func<T, TKey>> expression);
        T GetById(K id);
    }
}
