using System;
using System.Collections.Generic;

namespace nickelback
{
    class Program
    {
        static void Main(string[] args)
        {

            // Define a list of dictionaries.
            // Each dictionary will have a key of type string, and a value of type string.
            // Assign the list to a goodSongs variable.

            List<Dictionary<string, string>> goodSongs = new List<Dictionary<string, string>>();

            // Define a HashSet, named allSongs, that contains 7 dictionaries.
            // Each dictionary in the set will have a key of type string, and a value of type string.
            // The key will be the name of an artist.
            // The value will be the name of a song by that artist. Make sure that some of the songs are from the band Nickelback. You can see a list of their greatest hits on Amazon.
            // // Example
            // HashSet<Dictionary<string, string>> allSongs = new HashSet<Dictionary<string, string>>();
            HashSet<Dictionary<string, string>> allSongs = new HashSet<Dictionary<string, string>>(){

            new Dictionary<string,string>(){{"Nickelback","How You Remind Me"}},
            new Dictionary<string,string>(){{"Nickelback","Burn it to the ground"}},
            new Dictionary<string,string>(){{"Post Malone","Wow"}},
            new Dictionary<string,string>(){{"Ariana Grande","Thank you next"}},
            new Dictionary<string,string>(){{"Lil Nas X","Old Town Road"}},
            new Dictionary<string,string>(){{"Halsey","High Hopes"}},
            new Dictionary<string,string>(){{"Drake","Nice for What"}}

};


            // Once the set is populated with 7 dictionaries, iterate over the set of songs, and check if the band name is "Nickelback".
            foreach (Dictionary<string, string> dictionary in allSongs)
            {

                foreach (KeyValuePair<string, string> song in dictionary)
                {
                    // If the band is not Nickelback, then add it to the goodSongs list.
                    if (song.Key != "Nickelback")
                    {
                        goodSongs.Add(new Dictionary<string,string>{{song.Key, song.Value}});
                    }
                }

            }

            // Use another foreach loop to print out all the good songs.
            Console.WriteLine($"These are the good Songs");

            foreach (Dictionary<string, string> dictionary in goodSongs)
            {

                foreach (KeyValuePair<string, string> song in dictionary)
                {
                    Console.WriteLine($"  -'{song.Value}' by {song.Key}");

                }
            }

        }
    }
}
