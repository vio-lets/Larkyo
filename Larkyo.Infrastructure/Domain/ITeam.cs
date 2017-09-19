using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.Infrastructure.Domain
{
    public interface ITeam
    {
         string Title { get; set; }

         Boolean JoinedConfirm { get; set; }


         int MaxUser { get; set; }

         string Tags { get; set; }

        string Description { get; set; }

    }
   
}
