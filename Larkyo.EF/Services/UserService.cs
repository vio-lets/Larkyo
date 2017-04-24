using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Infrastructure.Services;
using Larkyo.EF.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace Larkyo.EF.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
        }

        public IList<IUser> GetApplicationUsers()
        {
            IList<IUser> users = null;
            using (LarkyoContext context = new LarkyoContext())
            {
                ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                users = userManager.Users.ToList<IUser>();
            }

            return users;
        }

        public async Task<IUser> FindAsync(string userName, string password)
        {
            IUser user = null;

            using (LarkyoContext context = new LarkyoContext())
            {
                ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                user = await userManager.FindAsync(userName, password);
            }
            return user;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(string userName, string password, string authenticationType)
        {
            using (LarkyoContext context = new LarkyoContext())
            {
                ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                ApplicationUser user = await userManager.FindAsync(userName, password);

                return await userManager.CreateIdentityAsync(user, authenticationType);
            }
        }
    }
}
