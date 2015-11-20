using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BetterSteamWebAPIDocumentation.Startup))]
namespace BetterSteamWebAPIDocumentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
