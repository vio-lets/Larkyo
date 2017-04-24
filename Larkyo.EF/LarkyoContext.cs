using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Larkyo.EF.Identity;
using Larkyo.EF.Migrations;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace Larkyo.EF
{
    public class LarkyoContext : ApplicationDbContext
    {
        public LarkyoContext()
            :base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer( new MigrateDatabaseToLatestVersion<LarkyoContext, Configuration>());
        }
    }
}
