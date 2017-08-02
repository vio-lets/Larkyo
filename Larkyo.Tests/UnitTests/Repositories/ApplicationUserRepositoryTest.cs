using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using NUnit.Framework;
using Larkyo.Core.Domain;
using Larkyo.Domain;
using Larkyo.Infrastructure.Data;
using Larkyo.Infrastructure.Services;
using Larkyo.Infrastructure.Repositories;
using Larkyo.EF;
using Larkyo.EF.Repositories;
using Larkyo.EF.Services;


namespace Larkyo.Tests.UnitTests.Repositories
{
    [TestFixture]
    class ApplicationUserRepositoryTest
    {
        [OneTimeSetUp]
        public void Init()
        {
            Debug.Print("Init Test");
            IUserService userService = new UserService();
            IUser<string> result = userService.CreateUser("alfred", "test123");
            IUser<string> user2 = userService.CreateUser("moana", "test123");
            IUser<string> user3 = userService.CreateUser("wayne", "test123");
            
        }

        [TestCase]
        public void TestSingleOrDefault()
        {
            IRepository<ApplicationUser> repository = new ApplicationUserRepository();
            ApplicationUser admin = repository.SingleOrDefault(u => u.UserName == "admin");

            Assert.IsNotNull(admin);
        }

        [TestCase]
        public void TestFindAll()
        {
            IRepository<ApplicationUser> repository = new ApplicationUserRepository();
            IEnumerable<ApplicationUser> result = repository.FindAll();

            Assert.AreEqual(4, result.Count());
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings["DefaultConnection"];

            if(css != null)
            {
                using (SqlConnection connection = new SqlConnection(css.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "delete from UserProfiles where Id in (select Id from AspNetUsers where UserName in ('alfred', 'moana', 'wayne'))";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "delete from AspNetUsers where username in ('alfred','moana','wayne')";
                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
    }
}
