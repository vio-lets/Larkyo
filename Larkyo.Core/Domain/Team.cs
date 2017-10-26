using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.Core.Domain
{
    public class Team<TUser, TTrip>
    {
        public Team()
        {
            Coordinators = new List<TUser>();
            Members = new List<TUser>();
          
        }

        public Guid TeamId { get; set; }

        public virtual string Title { get; set; }

        public virtual Boolean JoinedConfirm { get; set; }


        public virtual int MaxUser { get; set; }

        public virtual string Tags { get; set; }

        public virtual string Description { get; set; }


        public virtual TUser Promoter { get; set; }

        public virtual ICollection<TUser> Coordinators { get; private set; }

        public virtual ICollection<TUser> Members { get; private set; }



       
        public virtual TTrip Trip{ get; set; }



    }


}
