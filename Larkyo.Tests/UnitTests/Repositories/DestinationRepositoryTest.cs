using Larkyo.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Larkyo.EF.Repositories; 
using Larkyo.Infrastructure.Repositories;

namespace Larkyo.Tests.UnitTests.Repositories
{
    [TestFixture]
    class DestinationRepositoryTest
    {
        [TestCase]
        public void TestFindAllDestination()
        {
            IRepository<DestinationDomain> repo = new DestinationRepository();
            List<DestinationDomain> destList = repo.FindAll().ToList();
            Assert.AreEqual(4, destList.Count()); 
        }
    }
}
