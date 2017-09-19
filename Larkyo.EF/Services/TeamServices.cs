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
using System.Data.Entity.Infrastructure;

namespace Larkyo.EF.Services
{
    public class TeamServices
    {

        TeamRepository _teamRepository;

        public TeamServices(TeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public void CreateTeam(CreateTeamModel teamModel)
        {
            Team newTeam = new Team()
            {
                Title = teamModel.title,
                Tags = teamModel.tags,
                MaxUser = teamModel.maxUsers,
                JoinedConfirm = teamModel.joinedConfirm,
                Description = teamModel.description
                
            };

            if(_teamRepository.AddNewTeam(newTeam).Result<=0)
            {
                throw new DbUpdateException("Add new team failed");
            }
            
        }



    }
}
