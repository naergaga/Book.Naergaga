using Book.Naergaga.Models.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Service.BaseSerivces
{
    public class EntityService<T, K> : IEntityService<T, K> where T : class
    {
        internal DbContext _context;
        internal IDbSet<T> _dbset;

        public EntityService(DbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public bool Create(T entity)
        {
            if (entity == null) return false;
            _dbset.Add(entity);
            return _context.SaveChanges()>0;
        }

        public bool Delete(K id)
        {
            var item = _dbset.Find(id);
            if (item == null) return false;
            _context.Entry<T>(item).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }

        public List<T> GetAll()
        {
            return _dbset.ToList();
        }

        public T GetById(K id)
        {
            return _dbset.Find(id);
        }

        public bool Update(T entity)
        {
            if (entity == null) return false;
            _context.Entry<T>(entity).State = EntityState.Modified;
            return _context.SaveChanges()>0;
        }

        public List<T> GetPage<TKey>(PageOption option, Expression<Func<T, TKey>> expression)
        {
            if (option.Asc)
            {
                return _dbset.OrderBy(expression).Skip((option.CurrentPage - 1) * option.PageSize).Take(option.PageSize).ToList();
            }
            else
            {
                return _dbset.OrderByDescending(expression).Skip((option.CurrentPage - 1) * option.PageSize).Take(option.PageSize).ToList();
            }
        }

        public int CountPage(int pageSize)
        {
            return (int)Math.Ceiling(_dbset.Count() / (double)pageSize);
        }
    }
}
