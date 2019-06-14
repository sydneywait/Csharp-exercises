using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class ClientTrip
    {

        public int Id { get; set; }
        public int TripId { get; set; }
        public int ClientId { get; set; }
        public bool isArchived { get; set; }
        public Trip trip { get; set; }
        public Client client { get; set; }
    }
}
