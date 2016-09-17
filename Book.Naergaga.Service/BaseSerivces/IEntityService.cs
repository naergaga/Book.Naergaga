using System;
using System.Collections.Generic;
using System.Linq;
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
        T GetById(K id);
    }
}
