using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameStore.UI.Utils
{
    public class AppUserManager: UserManager<IdentityUser>
    {
        public AppUserManager(IUserStore<IdentityUser> store): base(store)
        {
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext owinContext)
        {
            var dbContext = owinContext.Get<DbContext>();
            var manager = new AppUserManager(new UserStore<IdentityUser>(dbContext));
            manager.UserValidator = new UserValidator<IdentityUser>(manager)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames = true,

            };
            manager.PasswordValidator = new PasswordValidator
            {
                RequireDigit = true,
                RequireLowercase = true,
                RequiredLength = 8,
                RequireUppercase = true,
            };

            // token
            return manager;
        }
    }
}