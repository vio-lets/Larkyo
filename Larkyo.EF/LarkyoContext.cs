﻿using System;
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
using Larkyo.Core.Domain;

namespace Larkyo.EF
{
    public class LarkyoContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
<<<<<<< HEAD
        public DbSet<Team> Teams { get; set; }
        public DbSet<Trip> Trips { get; set; }
=======
        public DbSet<DestinationDomain> Destinations { get; set; }
>>>>>>> 082964bf52d590d2d2d79cb6e43b0b0b04bff9c5

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
<<<<<<< HEAD

            /*
            modelBuilder.Entity<Team>()
                .HasMany<TeamRequirement>(x => x.Requires)
                .WithRequired(x=> x.Team);

            modelBuilder.Entity<Team>()
               .HasMany<Trip>(x => x.Trips)
               .WithRequired(x => x.AssociatedTeam);
               */
            modelBuilder.Entity<Trip>()
                .HasOptional<Team>(x => x.AssociatedTeam)
                .WithOptionalPrincipal(x=>x.Trip);
               
=======
            modelBuilder.Configurations.Add(new DestinationMapping()); 
>>>>>>> 082964bf52d590d2d2d79cb6e43b0b0b04bff9c5
        }
    }
}
