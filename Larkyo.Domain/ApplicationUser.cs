using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public UserProfile UserProfile { get; set; }
    }
}
