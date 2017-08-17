using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Domain;
using Larkyo.EF.Identity;
using Larkyo.EF.Repositories;
using Larkyo.Infrastructure.Domain;
using Larkyo.Infrastructure.Repositories;
using Larkyo.Infrastructure.Services;
using Microsoft.AspNet.Identity;

namespace Larkyo.EF.Services
{
    class ApplicationUserService : IApplicationUserService<ApplicationUser>
    {
        private LarkyoContext _dbContext = new LarkyoContext();

        public ApplicationUser CreateUser(string userName, string password)
        {
            ApplicationUser newApplicationUser = null;
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
                    newApplicationUser = newUser;
                    newApplicationUser.UserProfile = CreateUserProfile(newApplicationUser.UserName, newApplicationUser.Id);
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

            return newApplicationUser;
        }

        private UserProfile CreateUserProfile(string userName, string id)
        {
            IRepository<ApplicationUser> userRepository = new ApplicationUserRepository();
            IRepository<UserProfile> userProfileRepository = new UserProfileRepository();
            ApplicationUser newUser = userRepository.SingleOrDefault(u => u.Id == id);
            UserProfile userProfile = new UserProfile()
            {
                Gender = Gender.MALE,
                Name = userName,
                User = newUser
            };

            userProfileRepository.Add(userProfile);

            return userProfile;
        }

        public IList<ApplicationUser> GetApplicationUsers()
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUserById(string id)
        {
            throw new NotImplementedException();
        }
    }

}

