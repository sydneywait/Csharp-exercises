using System;

namespace c__inheritance
{
    //
    class Room
    {
        public Room(int widthParam, int lengthParam)
        {
            width = widthParam;
            length = lengthParam;
        }

        private int width { get; set; }
        private int length { get; set; }

        public int ceilingHeight { get; set; }

        public int area
        {
            get
            {
                return width * length;
            }
        }

        public Building Building { get; set; }
    }
}