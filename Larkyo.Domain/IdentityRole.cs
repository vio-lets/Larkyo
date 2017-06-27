using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Core.Domain;

namespace Larkyo.Domain
{
    /// <summary>
    ///     Represents a Role entity
    /// </summary>
    public class IdentityRole : IdentityRole<string, IdentityUserRole>
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        public IdentityRole()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="roleName"></param>
        public IdentityRole(string roleName)
            : this()
        {
            Name = roleName;
        }
    }
}
