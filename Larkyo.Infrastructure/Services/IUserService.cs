using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.Infrastructure.Services
{
    public interface IUserService
    {
        IList<IUser> GetApplicationUsers();
    }
}
