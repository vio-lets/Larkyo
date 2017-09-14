using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Larkyo.Domain;

namespace Larkyo.EF.Mappings
{
    public class TeamMapping:EntityTypeConfiguration<Team>
    {
        public TeamMapping()
        {


        }

    }
}
