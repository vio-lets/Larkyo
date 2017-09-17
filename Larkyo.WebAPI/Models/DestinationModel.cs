
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Larkyo.WebAPI.Models
{
    public class DestinationModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}