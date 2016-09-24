using Book.Naergaga.Models.Common;
using Book.Naergaga.Models.Entity;
using Book.Naergaga.Service.ModelService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Service.CommonService
{
    public class SearchService
    {
        private IBookService bookService;
        private IAuthorService authorService;

        public SearchService(IBookService service1, IAuthorService service2)
        {
            this.bookService = service1;
            this.authorService = service2;
        }

        public List<EBook> SearchBook(string keyword,PageOption option)
        {
            option.PageCount = option.CountPage(bookService.Count(b => b.Name.Contains(keyword)));
            return bookService.GetPage(option, b => b.Name.Contains(keyword),b => b.PostTime);
        }

        public List<Author> SearchAuthor(string keyword, PageOption option)
        {
            option.PageCount = option.CountPage(authorService.Count(b => b.Name.Contains(keyword)));
            return authorService.GetPage(option, b => b.Name.Contains(keyword), b => b.Name);
        }
    }
}
