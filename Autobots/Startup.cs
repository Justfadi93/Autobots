using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autobots.Startup))]
namespace Autobots
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
