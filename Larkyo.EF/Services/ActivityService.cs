using Larkyo.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Infrastructure.Domain;
using Larkyo.Domain;
using Larkyo.Infrastructure.Repositories;

namespace Larkyo.EF.Services
{
    public class ActivityService : IActivityService
    {
        private IRepository<DestinationDomain> _destRepo; 

        public ActivityService(IRepository<DestinationDomain> destRepo)
        {
            _destRepo = destRepo; 
        }

        public IList<IDestination> GetAllDestinations()
        {
            return _destRepo.FindAll().ToList<IDestination>(); 
        }
    }
}
