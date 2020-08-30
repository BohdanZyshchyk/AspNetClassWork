using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using GameStore.DAL;
using GameStore.UI.Utils;

[assembly: OwinStartup(typeof(GameStore.UI.Startup))]

namespace GameStore.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<DbContext>(() => new ApplicationContext());
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<UserSignInManager>(UserSignInManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Auth/Login")
                
            });
        }
    }
}
