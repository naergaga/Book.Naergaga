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
    public class TagService : EntityService<Tag,int>, ITagService
    {

        public TagService(DataContext context) : base(context) { }
    }
}
