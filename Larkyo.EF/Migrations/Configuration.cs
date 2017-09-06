using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Larkyo.Domain;
using Larkyo.EF.Identity;
using Larkyo.Infrastructure.Domain;

namespace Larkyo.EF.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<LarkyoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Larkyo.EF.LarkyoContext";
        }

        protected override void Seed(LarkyoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //---seed Destination table
            context.Destinations.AddOrUpdate(
                d => d.Name,
                new DestinationDomain { Id = Guid.NewGuid().ToString(), Name = "Auckland", Country = "New Zealand", Region = "North Island", Latitude = -36.850933, Longitude = 174.764491 },
                new DestinationDomain { Id = Guid.NewGuid().ToString(), Name = "Rotorua", Country = "New Zealand", Region = "North Island", Latitude = -38.135376, Longitude = 176.253787 },
                new DestinationDomain { Id = Guid.NewGuid().ToString(), Name = "Wellington", Country = "New Zealand", Region = "South Island", Latitude = -41.286453, Longitude = 174.776238 },
                new DestinationDomain { Id = Guid.NewGuid().ToString(), Name = "Hamilton", Country = "New Zealand", Region = "North Island", Latitude = -37.787221, Longitude = 175.283010 }
                );

            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if(context.Users.SingleOrDefault(u => u.UserName == "admin") == null)
            {
                ApplicationUser admin = new ApplicationUser()
                {
                    UserName = "admin",
                    Email = "violet@larkyo.com",
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.Create(admin, "Larkyo.123");

                UserProfile adminUserProfile = new UserProfile()
                {
                    Name = "Administrator",
                    Gender = Gender.NOT_APPLICABLE
                };

                if (result.Succeeded)
                {
                    admin.UserProfile = adminUserProfile;
                    context.Entry(admin).State = EntityState.Modified;
                }
                else
                {
                    admin = context.Users.SingleOrDefault(u => u.UserName == "admin");
                    if (admin != null)
                    {
                        admin.UserProfile = adminUserProfile;
                    }
                }
            }

            foreach (ApplicationUser user in context.Users.Include(u => u.UserProfile))
            {
                if(user.UserProfile == null)
                {
                    user.UserProfile = new UserProfile()
                    {
                        Name = user.UserName,
                        Gender = Gender.UNKNOWN
                    };
                }
            }

            context.SaveChanges();
        }
    }
}
