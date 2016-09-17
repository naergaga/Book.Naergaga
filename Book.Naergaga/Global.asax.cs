using Book.Naergaga.App_Start;
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
        IKernel kernel = NinjectWebCommon.CreateKernel();

        protected void Application_Start()
        {
            ConfigAutoMapper(kernel.Get<IBookTagsService>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        [Inject]
        public void ConfigAutoMapper(IBookTagsService service1)
        {
            AutoMapper.Mapper.Initialize(c =>
            {
                c.CreateMap<Tag, TagViewModel>().AfterMap((s,d)=> {
                    d.Count = service1.CountTag(s.Id);
                });
            });
        }
    }
}
