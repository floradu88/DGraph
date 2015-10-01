using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DGraph.Web.Startup))]
namespace DGraph.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
