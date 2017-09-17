using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Larkyo.Domain
{
    public class Trip
    {
        public Trip()
        {
        //    UserIds = new List<string>();
        }
        public int TripId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public int Views { get; set; }
        public decimal EstimateCost { get; set; }

        
        public Larkyo.Domain.Team AssociatedTeam { get; set; }    
        // ?Store a group of image Ids
       // public ICollection<string> ImageIds { get; set; }

      

    }

}
