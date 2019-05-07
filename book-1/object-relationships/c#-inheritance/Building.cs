using System;
using System.Collections.Generic;

namespace c__inheritance
{
    class Building
    {
        public List<Room> Rooms { get; set; } = new List<Room>();
        public double totalArea
        {
            get
            {
                int areaSum = 0;

                Rooms.ForEach(r =>
                {
                    areaSum += r.area;

                });
                return areaSum;
            }
        }
        public double getAverageRoomSize
        {
            get
            {
                return totalArea / Rooms.Count;
            }
        }

        // Add a method on the building class to add a room.
        // This method should assign the Building property on the given room and add the given room to the building's list of rooms.

        public void addRoomToBuilding(Room roomParam)
        {

            Rooms.Add(roomParam);
            roomParam.Building = this;

        }
        public void estimateCost(double costParam, string buildingName)
        {
            double totalCost = totalArea * costParam;

            Console.WriteLine($"The estimated total cost of {buildingName} is ${totalCost}");
        }
    }
}