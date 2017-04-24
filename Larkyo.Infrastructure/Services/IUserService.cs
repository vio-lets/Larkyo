using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.Infrastructure.Services
{
    public interface IUserService
    {
        IList<IUser> GetApplicationUsers();
        Task<IUser> FindAsync(string userName, string password);
        Task<ClaimsIdentity> GenerateUserIdentityAsync(string userName, string password, string authenticationType);
    }
}
