using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models.ViewModels
{
    public class TripReportViewModel
    {

        public List<TripReport> BusyMonths { get; set; }
        public List<ClientReport> BusyClients { get; set; }

    }
}
