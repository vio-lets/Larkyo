using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Larkyo.EF.Services;
using Larkyo.Domain;
using Larkyo.EF.Repositories;
using Larkyo.Infrastructure.Repositories;
using Larkyo.Infrastructure.Domain;

namespace Larkyo.Tests.UnitTests.Services
{
    [TestFixture]
    class ActivityServiceTest
    {
        [TestCase]
        public void TestGetAllDestinations()
        {
            IRepository<DestinationDomain> destRepo = new DestinationRepository();
            ActivityService activityService = new ActivityService(destRepo);
            IList<IDestination> destList = activityService.GetAllDestinations();
            var destlist = destList.Select(d => new DestinationDomain
            {
                Id = d.Id,
                Name = d.Name,
                Country = d.Country,
                Region = d.Region,
                Latitude = d.Latitude,
                Longitude = d.Longitude
            });

            Assert.AreEqual(4, destlist.Count()); 
        }
    }
}
