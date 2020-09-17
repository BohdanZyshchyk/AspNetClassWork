using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameStore.UI.Startup))]
namespace GameStore.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
