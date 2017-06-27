using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.EF.Identity;
using Larkyo.EF.Migrations;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace Larkyo.EF
{
    public class LarkyoContext : IdentityDbContext
    {
        public LarkyoContext()
            :base("DefaultConnection")
        {
            Database.SetInitializer( new MigrateDatabaseToLatestVersion<LarkyoContext, Configuration>());
        }
    }
}
