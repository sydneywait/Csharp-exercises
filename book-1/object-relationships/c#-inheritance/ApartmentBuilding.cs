using System;
using System.Collections.Generic;

namespace c__inheritance{
    class ApartmentBuilding:Building
    {
        public ApartmentBuilding()
        {
            numberOfUnits=Rooms.Count;
        }

        public int numberOfUnits {get; set;}


    }
}