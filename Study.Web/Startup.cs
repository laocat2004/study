using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Study.Web.Startup))]
namespace Study.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
