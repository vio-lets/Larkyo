using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Larkyo.Infrastructure.Domain;

namespace Larkyo.Infrastructure.Services
{
    public interface IApplicationUserService<TUser>
        where TUser : IUser<string>
    {
        TUser CreateUser(string userName, string password);
        Task<TUser> CreateUserAsync(string userName, string password);
    }
}
