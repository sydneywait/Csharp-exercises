using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models.ViewModels
{
    public class TripViewModel
    {

        public SelectList Clients { get; set; }
        public Trip trip { get; set; }
    }
}
