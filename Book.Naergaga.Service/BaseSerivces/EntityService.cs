using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Service.BaseSerivces
{
    public class EntityService<T, K> : IEntityService<T, K> where T : class
    {
        private DbContext _context;
        private IDbSet<T> _dbset;

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
    }
}
