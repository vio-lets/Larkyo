using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Larkyo.EF.Identity;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace Larkyo.EF
{
    public class LarkyoContext : IdentityDbContext<ApplicationUser>
    {
        public LarkyoContext()
            :base("DefaultConnection", throwIfV1Schema: false)
        {

        }
    }
}
