using System;

namespace interface_animals{
    public interface ISwimming{
        void swim();
        int maxDepth {get; set;}
        bool isMammal {get; set;}
        bool isSaltWater {get; set;}

    }
}