using AutoMapper;
using Book.Naergaga.Models.Common;
using Book.Naergaga.Models.PublicView;
using Book.Naergaga.Models.ViewModel;
using Book.Naergaga.Service.ModelService.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Naergaga.Controllers
{
    public class BookController : Controller
    {
        IBookService bookService;
        private IAuthorService authorService;
        private ICategoryService categoryService;

        public BookController(IBookService service, IAuthorService service2, ICategoryService categoryService)
        {
            this.bookService = service;
            this.authorService = service2;
            this.categoryService = categoryService;
        }

        // GET: Book
        [Route("Book/{id:int}")]
        public ActionResult Index(int? id)
        {
            if (id==null)
            {
                return RedirectToAction("index", "Home", null);
            }
            var book = bookService.GetById(id);
            return View(Mapper.Map<EBookViewModel>(book));
        }

        [Route("")]
        //[Route("Page{CurrentPage:int}")]
        public ActionResult HomeBook()
        {
            var cates = categoryService.GetAll();
            var option = new PageOption
            {
                Asc = false,
                CurrentPage = 1,
                PageSize = 20,
                PageCount =1
            };
            foreach (var item in cates)
            {
                item.Books = bookService.GetPage(option, c => c.CategoryId == item.Id, c => c.PostTime);
            }

           var books = bookService.GetPage(option, c => c.PostTime);
            var model = new HomeIndexViewModel
            {
                Option = option,
                Lists = cates,
                Books =books
            };
            return View(model);
        }

        [Route("Author/{authorId:int}",Order =1)]
        [Route("Author/{authorId:int}/Page{currentPage:int}",Order =0)]
        public ActionResult AuthorBook(int authorId, int? currentPage)
        {
            var author = authorService.GetById(authorId);
            var option = new PageOption
            {
                Asc = false,
                CurrentPage = currentPage??1,
            };
            option.PageCount = option.CountPage(bookService.CountBookInAuthor(authorId));
            var books = bookService.GetPage(option, c => c.authorId == author.Id,c=>c.authorId);

            var model = new BookAuthorViewModel
            {
                Author = author,
                Books = books,
                Option = option
            };
            return View(model);
        }

        [Route("Category/{categoryId:int}/Page{currentPage:int}",Order =0)]
        [Route("Category/{categoryId:int}",Order =1)]
        public ActionResult CategoryBook(int categoryId, int? currentPage)
        {
            var item = categoryService.GetById(categoryId);
            var option = new PageOption
            {
                Asc = false,
                CurrentPage = currentPage??1,
            };
            option.PageCount = option.CountPage(bookService.CountBookInCategory(categoryId));
            var books = bookService.GetPage(option, c => c.CategoryId == item.Id, c=>c.CategoryId);

            var model = new BookCategoryViewModel
            {
                Category = item,
                Books = books,
                Option = option
            };
            return View(model);
        }

        [HttpGet]
        public FileStreamResult Down(int id)
        {
            var book = bookService.GetById(id);
            var path = Server.MapPath(book.Path);
            return File(new FileStream(path,FileMode.Open), "application/octet-stream",book.Name+".txt");
        }

    }
}