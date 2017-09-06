using Larkyo.Domain;
using Larkyo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Infrastructure.Data;
using System.Linq.Expressions;

namespace Larkyo.EF.Repositories
{
    public class DestinationRepository : EfEntityRepository<DestinationDomain, LarkyoContext>
    {
       
    }
}
