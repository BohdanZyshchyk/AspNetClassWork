using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.UI.Utils
{
    public class UserSignInManager:SignInManager<IdentityUser, string>
    {
        public UserSignInManager(AppUserManager manage, IAuthenticationManager authentication): base(manage, authentication)
        {
        }

        public static UserSignInManager Create(IdentityFactoryOptions<UserSignInManager> options, IOwinContext owinContext)
        {
            var userManager = owinContext.GetUserManager<AppUserManager>();

            var manager = new UserSignInManager(userManager, owinContext.Authentication);
           
            return manager;
        }
    }
}