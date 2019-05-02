using System;

namespace interface_animals{
    public interface IFlying{
        void fly();
        int maxHeight {get; set;}
        int speed {get; set;}
        bool hasFeathers {get; set;}

    }
}