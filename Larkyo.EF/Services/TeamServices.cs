using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Domain;
using Larkyo.Infrastructure.Domain;
using Larkyo.EF.Repositories;
using Larkyo.Infrastructure.Repositories;
using Larkyo.Infrastructure.Dto;

namespace Larkyo.EF.Services
{
    public class TeamServices
    {

        IRepository<Team> _teamRepository;

        public TeamServices(IRepository<Team> teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Guid CreateTeam(CreateTeamModel teamModel)
        {
            Team newTeam = new Team()
            {
                Title = teamModel.title,
                Tags = teamModel.tags,
                MaxUser = teamModel.maxUsers,
                JoinedConfirm = teamModel.joinedConfirm,
                Description = teamModel.description
                
            };


            _teamRepository.Add(newTeam);



            return Guid.NewGuid();
            
        }

    }
}
