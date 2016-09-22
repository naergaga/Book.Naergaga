using Book.Naergaga.App_Start;
using Book.Naergaga.Controllers;
using Book.Naergaga.Models.Entity;
using Book.Naergaga.Models.ViewModel;
using Book.Naergaga.Service.ModelService.Interface;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Book.Naergaga
{
    public class MvcApplication : System.Web.HttpApplication
    {
        IKernel kernel = NinjectWebCommon.GetKernel();

        protected void Application_Start()
        {
            ConfigAutoMapper(kernel.Get<IBookTagsService>(), kernel.Get<IBookService>(), kernel.Get<IAuthorService>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected void Application_Error()
        //{
        //    Exception ex = Server.GetLastError();
        //    Server.ClearError();

        //    RouteData routeData = new RouteData();
        //    routeData.Values.Add("controller", "Error");
        //    routeData.Values.Add("action", "Index");
        //    routeData.Values.Add("exception", "exception");

        //    if (ex.GetType() == typeof(HttpException))
        //    {
        //        routeData.Values.Add("statusCode", (ex as HttpException).GetHttpCode());
        //    }
        //    else
        //    {
        //        routeData.Values.Add("statusCode", 500);
        //    }

        //    IController controller = new ErrorController();
        //    controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        //    Response.End();
        //}

        [Inject]
        public void ConfigAutoMapper(IBookTagsService service1, IBookService service2, IAuthorService service3)
        {
            AutoMapper.Mapper.Initialize(c =>
            {
                c.CreateMap<Tag, TagViewModel>().AfterMap((s,d)=> {
                    d.Count = service1.CountTag(s.Id);
                });
                c.CreateMap<Category, CategoryViewModel>().AfterMap((s, d) => {
                    d.BookCount = service2.CountBookInCategory(s.Id);
                });
                c.CreateMap<Author, AuthorViewModel>().AfterMap((s, d) => {
                    d.BookCount = service2.CountBookInAuthor(s.Id);
                });
                c.CreateMap<EBook, EBookViewModel>().AfterMap((s, d) => {
                    d.AuthorName = service3.GetById(s.authorId).Name;
                });
            });
        }
    }
}
