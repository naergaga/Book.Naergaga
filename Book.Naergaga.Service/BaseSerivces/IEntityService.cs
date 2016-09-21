using Book.Naergaga.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Service.BaseSerivces
{
    public interface IEntityService<T> where T:class
    {
        bool Create(T entity);
        bool Delete(params object[] values);
        bool Update(T entity);
        List<T> GetAll();
        int Count();
        List<T> GetPage<TKey>(PageOption option, Expression<Func<T, TKey>> expression);
        T GetById(params object[] values);
    }
}
