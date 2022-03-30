using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BARG.Startup))]
namespace BARG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
