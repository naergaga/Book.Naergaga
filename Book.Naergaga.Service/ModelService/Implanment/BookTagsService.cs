﻿using Book.Naergaga.Models.Entity;
using Book.Naergaga.Models.EntityContext;
using Book.Naergaga.Service.BaseSerivces;
using Book.Naergaga.Service.ModelService.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Service.ModelService.Implanment
{
    public class BookTagsService : EntityService<BookTags>, IBookTagsService
    {

        public BookTagsService(DataContext context) : base(context) { }

        public int CountTag(int bookId)
        {
            return _dbset.Where(c => c.BookId == bookId).Count();
        }

        public List<BookTags> GetListFull()
        {
            return _dbset.Include(b => b.Book).Include(b => b.Tag).ToList();
        }
    }
}
