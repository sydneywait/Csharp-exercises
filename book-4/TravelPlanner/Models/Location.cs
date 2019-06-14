using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class Location
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<TripLocation> TripLocations { get; set; } = new List<TripLocation>();
       
    }
}
