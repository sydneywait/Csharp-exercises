using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class Location
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Trip>Trips { get; set; }
        public List<Client> Clients { get; set; }
    }
}
