using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Larkyo.EF;
using Larkyo.EF.Identity;

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

            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            ApplicationUser user = new Identity.ApplicationUser()
            {
                UserName = "admin",
                Email = "violet@larkyo.com",
                EmailConfirmed = true
            };

            userManager.Create(user, "Larkyo.123");
        }
    }
}
