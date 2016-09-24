using Book.Naergaga.Models.Common;
using Book.Naergaga.Models.Entity;
using Book.Naergaga.Models.EntityContext;
using Book.Naergaga.Service.BaseSerivces;
using Book.Naergaga.Service.ModelService.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Service.ModelService.Implanment
{
    public class BookService:EntityService<EBook>,IBookService
    {

        public BookService(DataContext context) : base(context) { }

        public int CountBookInAuthor(int authorId)
        {
            return _dbset.Where(b => b.authorId == authorId).Count();
        }

        public int CountBookInCategory(int categoryId)
        {
            return _dbset.Where(b => b.CategoryId == categoryId).Count();
        }

        public List<EBook> GetPageFull<TKey>(PageOption option, Expression<Func<EBook, TKey>> expression)
        {
            if (option.Asc)
            {
                return _dbset.OrderBy(expression).Skip((option.CurrentPage - 1) * option.PageSize).Include(c=>c.Author).Include(c=>c.Category).Take(option.PageSize).ToList();
            }
            else
            {
                return _dbset.OrderByDescending(expression).Skip((option.CurrentPage - 1) * option.PageSize).Take(option.PageSize).ToList();
            }
        }

    }
}
