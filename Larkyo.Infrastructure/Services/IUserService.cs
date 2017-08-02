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
        IList<IUser<string>> GetApplicationUsers();
        Task<IUser<string>> FindAsync(string userName, string password);
        Task<IUser<string>> GetUserById(string id);
        IUser<string> CreateUser(string userName, string password);
        Task<IUser<string>> CreateUserAsync(string userName, string password);
        Task<ClaimsIdentity> GenerateUserIdentityAsync(string userName, string password, string authenticationType);
        
    }
}
