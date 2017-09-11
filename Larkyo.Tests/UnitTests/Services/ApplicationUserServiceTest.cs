using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Larkyo.Domain;
using Larkyo.EF.Services;

namespace Larkyo.Tests.UnitTests.Services
{
    [TestFixture]
    class ApplicationUserServiceTest
    {
        private string _connectionString;

        [SetUp]
        public void TestCaseInit()
        {
            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            _connectionString = css.ConnectionString;
        }

        [TearDown]
        public void TestCaseCleanup()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from UserProfiles where Id in (select Id from AspNetUsers where UserName = 'test')";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "delete from AspNetUsers where username = 'test'";
                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        [TestCase]
        public async Task TestCreateUser()
        {
            ApplicationUserService service = new ApplicationUserService();
            ApplicationUser user = await service.CreateUserAsync("test", "test123");

            Assert.IsNotNull(user);
            Assert.IsNotNull(user.UserProfile);

            Assert.AreEqual("test", user.UserName);
            Assert.AreEqual("test", user.UserProfile.Name);
        }
    }
}
