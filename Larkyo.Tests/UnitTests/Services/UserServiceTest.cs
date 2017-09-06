using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.AspNet.Identity;
using Larkyo.Infrastructure.Services;
using Larkyo.EF.Services;

namespace Larkyo.Tests.UnitTests.Services
{
    [TestFixture]
    class UserServiceTest
    {
        [TestCase]
        public void TestAdminAccountExists()
        {
            IUserService service = new UserService();
            Task<IUser<string>> answer = service.FindAsync("admin", "Larkyo.123");
            answer.Wait();

            Assert.IsNotNull(answer.Result);
            Assert.AreEqual("admin", answer.Result.UserName);
        }
    }
}
