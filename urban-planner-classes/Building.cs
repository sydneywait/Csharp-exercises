using System;

namespace Planner
{

    //     Private Fields
    // _designer of type string. It will hold your name.
    // _dateConstructed of type DateTime. This will hold the exact time the building was created.
    // _address of type string.
    // _owner of type string. This will store the same of the person who owns the building.

    // Public Properties
    // Stories typed as an integer.
    // Width typed as a double.
    // Depth typed as a double.
    // Volume should be read-only and should return width * depth * (3 * # of stories). Each story is 3 meters high.

    class Building
    {
        public Building(string addressParam)
        {
            _address = addressParam;
            _designer="Sydney Wait";
        }
        private string _designer { get; set; }
        private DateTime _dateConstructed { get; set; }
        private string _address { get; set; }
        private string _owner { get; set; }
        public int stories { get; set; }
        public double width { get; set; }
        public double depth { get; set; }
        public double volume {
            get{
                return width * depth * (3 * stories);
            }
            }
        public void Construct()
        {
            _dateConstructed = DateTime.Now;

        }
        public void Purchase(string nameParam)
        {
            _owner = nameParam;
        }
        public void DisplayInfo(){
        Console.WriteLine("                                 ");
        Console.WriteLine(_address);
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"Designed by {_designer}");
        Console.WriteLine($"Constructed on {_dateConstructed}");
        Console.WriteLine($"Owned by {_owner}");
        Console.WriteLine($"{volume} cubic meters of space");

        }




    }

}