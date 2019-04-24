using System;
using System.Collections.Generic;

namespace dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Create a dictionary with key value pairs to
                represent words (key) and its definition (value)
            */
            Dictionary<string, string> wordsAndDefinitions = new Dictionary<string, string>();

            // Add several more words and their definitions
            wordsAndDefinitions.Add("Awesome", "The feeling of students when they are learning C#");
            wordsAndDefinitions.Add("Monday", "The worst day of the week");
            wordsAndDefinitions.Add("Taco", "It can be anything, really");
            wordsAndDefinitions.Add("brutiful", "The beautiful brutal process of learning to code. ");

            /*
                Use square bracket lookup to get the definition two
                words and output them to the console
            */

            Console.WriteLine(wordsAndDefinitions["Awesome"]);
            Console.WriteLine(wordsAndDefinitions["brutiful"]);
            /*
                Loop over dictionary to get the following output:
                    The definition of [WORD] is [DEFINITION]
                    The definition of [WORD] is [DEFINITION]
                    The definition of [WORD] is [DEFINITION]
            */
            foreach (KeyValuePair<string, string> word in wordsAndDefinitions)
            {
                Console.WriteLine($"The defintion of {word.Key} is {word.Value}");

            }

            // Make a new list
            List<Dictionary<string, string>> dictionaryOfWords = new List<Dictionary<string, string>>();

            /*
                You want to track the following about each word:
                    word, definition, part of speech, example sentence

                Example of one dictionary in the list:
                {
                    "word": "excited",
                    "definition": "having, showing, or characterized by a heightened state of energy, enthusiasm, eagerness",
                    "part of speech": "adjective",
                    "example sentence": "I am excited to learn C#!"
                }
            */

            // Create dictionary to represent a new word
            Dictionary<string, string> excitedWord = new Dictionary<string, string>();

            // Add each of the 4 bits of data about the word to the Dictionary
            excitedWord.Add("word", "excited");
            excitedWord.Add("definition", "having, showing, or characterized by a heightened state of energy, enthusiasm, eagerness");
            excitedWord.Add("part of speech", "adjective");
            excitedWord.Add("example sentence", "I am excited to learn C#!");


            // Add Dictionary to your `dictionaryOfWords` list
            dictionaryOfWords.Add(excitedWord);


            // create another Dictionary and add that to the list
            Dictionary<string, string> brutifulWord = new Dictionary<string, string>();
            brutifulWord.Add("word", "brutiful");
            brutifulWord.Add("definition", "Characterized by being beautiful and brutal");
            brutifulWord.Add("part of speech", "adjective");
            brutifulWord.Add("example sentence", "learning C# is very brutiful!");

            dictionaryOfWords.Add(brutifulWord);


            /*
                Iterate your list of dictionaries and output the data

                Example output for one word in the list of dictionaries:
                    word: excited
                    definition: having, showing, or characterized by a heightened state of energy, enthusiasm, eagerness
                    part of speech: adjective
                    example sentence: I am excited to learn C#!
            */

            // Iterate the List of Dictionaries

            dictionaryOfWords.ForEach(word =>
            {
                // Iterate the KeyValuePairs of the Dictionary
                foreach (KeyValuePair<string, string> wordData in word)
                {
                    Console.WriteLine($"{wordData.Key}: {wordData.Value}");
                }
                Console.WriteLine("-----------------------------------");


            });


            Dictionary<string, List<string>> idioms = new Dictionary<string, List<string>>();

            idioms.Add("Penny", new List<string> { "A", "penny", "for", "your", "thoughts" });
            idioms.Add("Injury", new List<string> { "Add", "insult", "to", "injury" });
            idioms.Add("Moon", new List<string> { "Once", "in", "a", "blue", "moon" });
            idioms.Add("Grape", new List<string> { "I", "heard", "it", "through", "the", "grapevine" });
            idioms.Add("Murder", new List<string> { "Kill", "two", "birds", "with", "one", "stone" });
            idioms.Add("Limbs", new List<string> { "It", "costs", "an", "arm", "and", "a", "leg" });
            idioms.Add("Grain", new List<string> { "Take", "what", "someone", "says", "with", "a", "grain", "of", "salt" });
            idioms.Add("Fences", new List<string> { "I'm", "on", "the", "fence", "about", "it" });
            idioms.Add("Sheep", new List<string> { "Pulled", "the", "wool", "over", "his", "eyes" });
            idioms.Add("Lucifer", new List<string> { "Speak", "of", "the", "devil" });

// Print the word and idiom phrase to the console
foreach (KeyValuePair<string, List<string>> idiom in idioms){
    string phrase ="";
    foreach (string word in idiom.Value){
        phrase = phrase + " " + word;
    }
    Console.WriteLine($"{idiom.Key}: {phrase}");
}

// Take the following JavaScript data structure that represents car sales and convert it to C# Lists and Dictionaries. Make sure that all of your variable names conform to the C# standard of Camel Case instead of Snake Case.
Dictionary<string, string> vehicle = new Dictionary<string,string>();

vehicle.Add("year", "2008");
vehicle.Add("model", "Damfresh");
vehicle.Add("make", "Biotraxquote");
vehicle.Add("color", "Sky Magenta");

Dictionary<string, string> salesId =new Dictionary<string,string>();

salesId.Add("salesId","ecb1c841-1a43-4a7c-896e-712d2ec39c71");

Dictionary<string,string> salesAgent=new Dictionary<string,string>();
salesAgent.Add("mobile", "(896) 478-6975");
salesAgent.Add("last_name","Botsford");
salesAgent.Add("first_name","Shaina");
salesAgent.Add("emails", "beatae_sonny@hotmail.com or shaina@aol.com");

Dictionary<string,string> purchaseDate=new Dictionary<string,string>();
purchaseDate.Add("purchase_date","2017-11-15");

Dictionary<string,string> grossProfit = new Dictionary<string,string>();
grossProfit.Add("gross_profit", "871.26");

Dictionary<string,string> credit = new Dictionary<string, string>();

credit.Add("credit_provider", "J.P.Morgan Chase & Co");
credit.Add("account", "601109582720302");

List<Dictionary<string,string>> Vehicles = new List<Dictionary<string,string>>(){
vehicle, salesId, salesAgent, purchaseDate, grossProfit, credit

};







// "vehicles": [
//     {
//         "vehicle": {
//             "year": 2008",
//             "model": "Damfresh",
//             "make": "Biotraxquote",
//             "color": "sky magenta"
//         },
//         "sales_id": "ecb1c841-1a43-4a7c-896e-712d2ec39c71",
//         "sales_agent": {
//             "mobile": "(896) 478-6975",
//             "last_name": "Botsford",
//             "first_name": "Shaina",
//             "emails": ["beatae_sonny@hotmail.com", "shaina@aol.com"]
//         },
//         "purchase_date": "2017-11-15",
//         "gross_profit": 871.26,
//         "credit": {
//             "credit_provider": "J.P.Morgan Chase & Co",
//             "account": "601109582720302"
//         }
//     },
//     {
//         "vehicle": {
//             "year": 2010,
//             "model": "Hotquadtrax",
//             "make": "Transtintechno",
//             "color": "robin egg blue"
//         },
//         "sales_id": "a2f80554-bd9d-4ea1-8229-01fd4cf220a8",
//         "sales_agent": {
//             "mobile": "562.300.2912",
//             "last_name": "Davis",
//             "first_name": "Gerardo",
//             "emails": ["girl70@hotmail.com", "jova43@gmail.com"]
//         },
//         "purchase_date": "2017-04-28",
//         "gross_profit": 156.02,
//         "credit": {
//             "credit_provider": "PNC Financial Services",
//             "account": "34578280562836"
//         }
//     }
// ]





            // end of Main
        }
    }
}
