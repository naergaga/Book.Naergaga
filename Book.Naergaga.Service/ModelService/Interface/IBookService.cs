using Book.Naergaga.Models.Entity;
using Book.Naergaga.Service.BaseSerivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Service.ModelService.Interface
{
    public interface IBookService : IEntityService<EBook, int>
    {
        int CountBookInCategory(int id);
    }
}
