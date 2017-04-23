using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.EF.Migrations;

namespace Larkyo.EF.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(string connectionString, bool throwIfV1Schema)
            :base(connectionString, throwIfV1Schema: throwIfV1Schema)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LarkyoContext, Configuration>());
        }

    }
}
