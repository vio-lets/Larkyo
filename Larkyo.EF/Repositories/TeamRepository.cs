using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Domain;

namespace Larkyo.EF.Repositories
{
    public class TeamRepository : EfEntityRepository<Team, LarkyoContext>
    {
        public async Task<int>  AddNewTeam(Team team)
        {
            int result;
            using (LarkyoContext context = new LarkyoContext())
            {
                context.Set<Team>().Add(team);

                result = await context.SaveChangesAsync();
            }

            return result;
        }
    }
}
