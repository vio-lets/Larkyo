using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Domain;

namespace Larkyo.EF.Mappings
{
    class UserProfileMapping : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMapping()
        {
            this.HasKey(up => up.Id)
                .HasRequired(up => up.User)
                .WithRequiredDependent(u => u.UserProfile);
        }
    }
}
