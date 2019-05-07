using System;
using System.Collections.Generic;

namespace c__inheritance{
    class House:Building
    {
        public House()
        {
            numberOfBedrooms=Rooms.Count;
        }

        public int numberOfBedrooms {get; set;}


    }
}