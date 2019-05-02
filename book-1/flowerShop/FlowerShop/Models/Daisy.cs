using System;

namespace flowerShop
{
    class Daisy:IMothersDayFlower,IWeddingFlower
    {
        public int stemLength { get; set; }
        public bool doesItSmellNice { get; set; }
        public string color { get; set; }
    }
}
