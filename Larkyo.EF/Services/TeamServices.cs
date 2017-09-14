using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Domain;
using Larkyo.Infrastructure.Domain;

namespace Larkyo.EF.Services
{
    public class TeamServices
    {
        

        public Guid CreateTeam(string PromoterId, string Title,Boolean JoinedConfirm=false,int MaxUser=26, String Tags="",string Descriptions="")
        {

            return Guid.NewGuid();

            
        }

    }
}
