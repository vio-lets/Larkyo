using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Domain;
using Larkyo.Infrastructure.Repositories;

namespace Larkyo.EF.Repositories
{
    public class TripRepository:EfEntityRepository<Trip,LarkyoContext>,IRepository<Trip>
    {
    }
}
