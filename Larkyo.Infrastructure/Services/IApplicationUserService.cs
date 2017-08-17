using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Infrastructure.Domain;

namespace Larkyo.Infrastructure.Services
{
    public interface IApplicationUserService<T> where T : class, IApplicationUser
    {
        IList<T> GetApplicationUsers();
        T CreateUser(string userName, string password);
        T GetUserById(string id);

    }
}
