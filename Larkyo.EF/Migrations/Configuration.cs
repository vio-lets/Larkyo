using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Larkyo.Domain;
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

            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));

            IdentityUser user = new IdentityUser()
            {
                UserName = "admin",
                Email = "violet@larkyo.com",
                EmailConfirmed = true
            };

            userManager.Create(user, "Larkyo.123");
        }
    }
}
