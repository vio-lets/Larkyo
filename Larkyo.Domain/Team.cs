using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Larkyo.Core.Domain;
using Larkyo.Infrastructure.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Larkyo.Domain
{
    public class Team: Team<ApplicationUser, Trip>,ITeam
    {

      /*  public Team()
        {
        //    Requires = new List<TeamRequirement>();

         
        }


     //   public virtual ICollection<TeamRequirement> Requires { get; set; }

    */

    }


  
}
