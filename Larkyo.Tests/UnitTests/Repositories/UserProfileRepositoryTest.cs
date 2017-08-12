using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using NUnit.Framework;
using Larkyo.Domain;
using Larkyo.EF.Repositories;
using Larkyo.EF.Services;
using Larkyo.Infrastructure.Domain;
using Larkyo.Infrastructure.Repositories;
using Larkyo.Infrastructure.Services;

namespace Larkyo.Tests.UnitTests.Repositories
{
    [TestFixture]
    class UserProfileRepositoryTest
    {
        private string _connectionString;

        [SetUp]
        public void TestCaseInit()
        {
            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            _connectionString = css.ConnectionString;

            IUserService userService = new UserService();
            IUser<string> result = userService.CreateUser("test", "test123");
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
        public void TestAdd()
        {
            IRepository<ApplicationUser> userRepository = new ApplicationUserRepository();
            ApplicationUser testUser = userRepository.SingleOrDefault(u => u.UserName == "test");

            IRepository<UserProfile> userProfileRepository = new UserProfileRepository();
            UserProfile userProfile = new UserProfile()
            {
                Gender = Gender.MALE,
                Name = "Test User",
                User = testUser
            };

            userProfileRepository.Add(userProfile);

            Assert.AreEqual(testUser.Id, userProfile.Id);
        }

        [TestCase]
        public void TestDelete()
        {
            IRepository<ApplicationUser> userRepository = new ApplicationUserRepository();
            ApplicationUser testUser = userRepository.SingleOrDefault(u => u.UserName == "test");

            IRepository<UserProfile> userProfileRepository = new UserProfileRepository();
            UserProfile userProfile = new UserProfile()
            {
                Gender = Gender.MALE,
                Name = "Test User",
                User = testUser
            };

            userProfileRepository.Add(userProfile);

            Assert.AreEqual(testUser.Id, userProfile.Id);

            userProfile = userProfileRepository.SingleOrDefault(up => up.Id == testUser.Id);

            Assert.IsNotNull(userProfile);

            userProfileRepository.Delete(userProfile);

            userProfile = userProfileRepository.SingleOrDefault(up => up.Id == testUser.Id);

            Assert.IsNull(userProfile);

            testUser = userRepository.SingleOrDefault(u => u.UserName == "test");

            Assert.IsNull(testUser.UserProfile);
        }
    }
}
