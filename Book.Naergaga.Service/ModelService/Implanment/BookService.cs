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
    public class BookService:EntityService<EBook,int>,IBookService
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
    }
}
