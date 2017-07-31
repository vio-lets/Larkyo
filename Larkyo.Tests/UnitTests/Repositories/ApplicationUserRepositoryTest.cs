using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Larkyo.Core.Domain;
using Larkyo.Domain;
using Larkyo.Infrastructure.Repositories;
using Larkyo.EF.Repositories;

namespace Larkyo.Tests.UnitTests.Repositories
{
    [TestFixture]
    class ApplicationUserRepositoryTest
    {
        [TestCase]
        public void TestSingleOrDefault()
        {
            IRepository<ApplicationUser> repository = new ApplicationUserRepository();
            ApplicationUser admin = repository.SingleOrDefault(u => u.UserName == "admin");

            Assert.IsNotNull(admin);
        }
    }
}
