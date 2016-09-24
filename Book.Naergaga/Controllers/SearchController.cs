using Book.Naergaga.Models.Common;
using Book.Naergaga.Models.Entity;
using Book.Naergaga.Models.PublicView;
using Book.Naergaga.Models.ViewModel;
using Book.Naergaga.Service.CommonService;
using Book.Naergaga.Service.ModelService.Implanment;
using Book.Naergaga.Service.ModelService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Book.Naergaga.Controllers
{
    public class SearchController : Controller
    {
        SearchService service;

        public SearchController(SearchService service)
        {
            this.service = service;
        }

        // GET: Search
        public ActionResult SearchInfo([Bind(Include ="Mode,Keyword")]SearchFormViewModel searchModel, int? page)
        {
            PageOption option = new PageOption {
                Asc =false,
                CurrentPage = page??1,
                PageSize = 15
            };

            var coll = new RouteValueDictionary();
            coll.Add("Mode", searchModel.Mode);
            coll.Add("Keyword", searchModel.Keyword);

            switch (searchModel.Mode)
            {
                case "book":
                    var books = service.SearchBook(searchModel.Keyword, option);
                    var model = new SearchViewModel<EBook>
                    {
                        Keyword = searchModel.Keyword,
                        List = books,
                        Option = option,
                        RouteData = coll
                    };
                    return View("BookSearch", model);
                case "author":
                    var author = service.SearchAuthor(searchModel.Keyword, option);
                    var model1 = new SearchViewModel<Author>
                    {
                        Keyword = searchModel.Keyword,
                        List = author,
                        Option = option,
                        RouteData = coll
                    };
                    return View("AuthorSearch", model1);
            }
            return RedirectToAction("HomeBook", "Book");
        }
    }
}