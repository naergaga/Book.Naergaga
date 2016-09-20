using System.Web.Mvc;

namespace Book.Naergaga.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                null,
                "Admin/{controller}/{action}/Page{currentPage}",
                new { action = "Index",controller="Books"},
                namespaces: new[] { "Book.Naergaga.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", controller = "Books",id = UrlParameter.Optional },
                namespaces:new[] {"Book.Naergaga.Areas.Admin.Controllers"}
            );
        }
    }
}