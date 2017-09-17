using Larkyo.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.EF.Mappings
{
    class DestinationMapping : EntityTypeConfiguration<DestinationDomain>
    {
        public DestinationMapping()
        {
            this.ToTable("Destinations");
            this.HasKey(d => d.Id);
           
        }
    }
}
