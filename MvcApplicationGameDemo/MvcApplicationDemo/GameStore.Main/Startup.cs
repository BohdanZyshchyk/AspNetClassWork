using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameStore.Main.Startup))]
namespace GameStore.Main
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
