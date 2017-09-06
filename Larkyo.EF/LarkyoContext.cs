using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Domain;
using Larkyo.EF.Identity;
using Larkyo.EF.Mappings;
using Larkyo.EF.Migrations;
using Larkyo.Infrastructure.Domain;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace Larkyo.EF
{
    public class LarkyoContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<DestinationDomain> Destinations { get; set; }

        public LarkyoContext()
            :base("DefaultConnection")
        {
            Database.SetInitializer( new MigrateDatabaseToLatestVersion<LarkyoContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ApplicationUserMapping());
            modelBuilder.Configurations.Add(new UserProfileMapping());
            modelBuilder.Configurations.Add(new DestinationMapping()); 
        }
    }
}
