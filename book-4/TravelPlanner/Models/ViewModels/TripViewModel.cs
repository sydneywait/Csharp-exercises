using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Models.ViewModels
{
    public class TripViewModel
    {

        public SelectList Clients { get; set; }
        public SelectList Locations { get; set; }
        public Trip trip { get; set; }
        [Display(Name = "Clients")]
        public List<int> selectedClients { get; set; } = new List<int>();
        [Display(Name = "Locations")]
        public List<int> selectedLocations { get; set;} = new List<int>();
    }
}
