using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using Larkyo.Domain;
using Larkyo.EF.Repositories;
using Larkyo.EF;

namespace Larkyo.Tests.UnitTests.Repositories
{
    [Author("Leon","liangren64@gmail.com")]
    [TestFixture]
    [Category("TeamTest")]
    class TeamRepositoryTest
    {
        private TeamRepository _teamRepository;
        private LarkyoContext _context;
        private TripRepository _tripRepository;
        private Trip _tripForTeam;
        public TeamRepositoryTest()
        {
            _teamRepository = new TeamRepository();
            _context = new LarkyoContext();
            _tripRepository = new TripRepository();
        }
        [SetUp]
        public void Init()
        {

            Trip newTrip = new Trip()
            {
                Views = 0,
                StartDate = DateTime.Parse("2017-09-15"),
                EndDate  = DateTime.Parse("2017-09-25"),
                Description = "This is a leisure trip",
                Duration = 5,
                EstimateCost = 5000,

            };
            _tripRepository.Add(newTrip);

            _tripForTeam = _tripRepository.FindAll().FirstOrDefault();

        }

        [Test]
        public void TestAddNewTeam()
        {
            Team newTeam = new Team
            {
                TeamId = Guid.NewGuid(),
                Description = "This is a new team fromn Larkyo",
                MaxUser = 10,
                Tags = "Camping, Skiing",
                Title = "Welcome",
                JoinedConfirm = true,
                
            };

            newTeam.Trip = _tripForTeam;
            int result = _teamRepository.AddNewTeam(newTeam).Result;

            Assert.That(result, Is.GreaterThan(0));
        }


 


    }
}
