using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Larkyo.Core.Domain;

namespace Larkyo.Domain
{
    /// <summary>
    ///     Default EntityFramework IUser implementation
    /// </summary>
    public class IdentityUser : IdentityUser<string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>, IUser
    {
        /// <summary>
        ///     Constructor which creates a new Guid for the Id
        /// </summary>
        public IdentityUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        ///     Constructor that takes a userName
        /// </summary>
        /// <param name="userName"></param>
        public IdentityUser(string userName)
            : this()
        {
            UserName = userName;
        }
    }
}
