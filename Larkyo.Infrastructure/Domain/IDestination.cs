using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.Infrastructure.Domain
{
    public interface IDestination
    {
        string Id { get; set; }
        string Name { get; set; }
        string Region { get; set; }
        string Country { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
    }
}
