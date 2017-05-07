using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Larkyo.Infrastructure.Services;
using Larkyo.EF.Identity;

namespace Larkyo.EF.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
        }

        public IList<IUser<string>> GetApplicationUsers()
        {
            IList<IUser<string>> users = null;
            using (LarkyoContext context = new LarkyoContext())
            {
                ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                users = userManager.Users.ToList<IUser<string>>();
            }

            return users;
        }

        public async Task<IUser<string>> FindAsync(string userName, string password)
        {
            IUser<string> user = null;

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

        public async Task<IUser<string>> GetUserById(string id)
        {
            IUser<string> user = null;

            using (LarkyoContext context = new LarkyoContext())
            {
                ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                user = await userManager.FindByIdAsync(id);
            }
            return user;
        }

        public async Task<IUser<string>> CreateUser(string userName, string password)
        {

            IUser<string> user = null;
            using (LarkyoContext context = new LarkyoContext())
            {
                ApplicationUser newUser = new ApplicationUser()
                {
                    UserName = userName
                };

                ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                IdentityResult result = await userManager.CreateAsync(newUser, password);

                if(result.Succeeded)
                {
                    user = newUser;
                }
            }

            return user;
        }
    }
}
