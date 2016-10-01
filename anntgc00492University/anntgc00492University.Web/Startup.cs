using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(anntgc00492University.Web.Startup))]
namespace anntgc00492University.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
