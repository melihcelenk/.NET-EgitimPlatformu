using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EgitimPlatformu.Startup))]
namespace EgitimPlatformu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
