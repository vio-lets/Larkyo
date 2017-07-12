using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Domain;

namespace Larkyo.EF.Mappings
{
    class ApplicationUserMapping : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserMapping()
        {
            this.ToTable("AspNetUsers");
            this.HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
            this.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
            this.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
            this.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex") { IsUnique = true }));

            // CONSIDER: u.Email is Required if set on options?
            this.Property(u => u.Email).HasMaxLength(256);

            this.HasRequired(u => u.UserProfile)
                .WithRequiredPrincipal(up => up.User);
        }
    }
}
