using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.EF.Identity
{
    class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}
