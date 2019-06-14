using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class TripLocation
    {

        public int Id { get; set; }
        public int TripId { get; set; }
        public int LocationId { get; set; }
        
        public Trip trip { get; set; }
        public Location location { get; set; }
    }
}
