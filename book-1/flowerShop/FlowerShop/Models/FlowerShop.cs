using System;
using System.Collections.Generic;

namespace flowerShop
{
    class FlowerShop
    {
        public List<Rose> createRoseBouquet()
        {


            return new List<Rose>(){
new Rose(){
    name = "Fire and Ice",
    color = "red and white",
    doesItSmellNice = true,
    isThorny = true

},
new Rose(){
    name = "Friendship",
    color = "yellow",
    doesItSmellNice = true,
    isThorny = false

},
new Rose(){
    name = "Dreamy",
    color = "white",
    doesItSmellNice = true,
    isThorny = true

},
new Rose(){
    name = "Cannon",
    color = "purple",
    doesItSmellNice = true,
    isThorny = true

}
 };



        }
        public List<Flower> createBouquet()
        {

            return new List<Flower>()
            {

            };





        }

        public List<IWeddingFlower> createWeddingBouquet()
        {
            return new List<IWeddingFlower>()
            {



            };
        }

        public List<IMothersDayFlower> createMothersDayBouquet()
        {
            return new List<IMothersDayFlower>(){
                new Daisy(){
                    stemLength = 6,
                    doesItSmellNice=true
                },
                new Tulip(){

                }

                };

            };
        }


        // end class
    }
}
