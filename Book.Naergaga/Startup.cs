using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Book.Naergaga.Startup))]
namespace Book.Naergaga
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
