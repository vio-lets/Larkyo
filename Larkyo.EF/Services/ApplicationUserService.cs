using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Larkyo.Domain;
using Larkyo.EF.Identity;
using Larkyo.EF.Repositories;
using Larkyo.Infrastructure.Services;

namespace Larkyo.EF.Services
{
    public class ApplicationUserService : IApplicationUserService<ApplicationUser>
    {
        public ApplicationUser CreateUser(string userName, string password)
        {
            ApplicationUser user = null;
            using (LarkyoContext context = new LarkyoContext())
            {
                ApplicationUser newUser = new ApplicationUser()
                {
                    UserName = userName
                };

                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                IdentityResult result = userManager.Create(newUser, password);

                if (result.Succeeded)
                {
                    user = newUser;

                    UserProfileRepository userProfileRepository = new UserProfileRepository();
                    userProfileRepository.Add(new UserProfile()
                    {
                        Name = userName,
                        User = newUser
                    });
                }
                else
                {
                    if (result.Errors != null)
                    {
                        IList<Exception> innerExceptions = new List<Exception>();
                        foreach (string errorMessage in result.Errors)
                        {
                            innerExceptions.Add(new Exception(errorMessage));
                        }
                        throw new AggregateException(innerExceptions);
                    }
                    throw new Exception("Unknown error.");
                }
            }

            return user;
        }

        public async Task<ApplicationUser> CreateUserAsync(string userName, string password)
        {
            ApplicationUser user = null;
            using (LarkyoContext context = new LarkyoContext())
            {
                ApplicationUser newUser = new ApplicationUser()
                {
                    UserName = userName
                };

                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                IdentityResult result = await userManager.CreateAsync(newUser, password);

                if (result.Succeeded)
                {
                    user = newUser;

                    UserProfileRepository userProfileRepository = new UserProfileRepository();
                    userProfileRepository.Add(new UserProfile()
                        {
                            Name = userName,
                            User = newUser
                        });
                }
                else
                {
                    if (result.Errors != null)
                    {
                        IList<Exception> innerExceptions = new List<Exception>();
                        foreach (string errorMessage in result.Errors)
                        {
                            innerExceptions.Add(new Exception(errorMessage));
                        }
                        throw new AggregateException(innerExceptions);
                    }
                    throw new Exception("Unknown error.");
                }
            }

            return user;
        }
    }
}
