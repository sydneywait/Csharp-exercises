using System;
using System.Collections.Generic;


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

        Console.WriteLine("-----------------------------------------------");

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
        foreach (KeyValuePair<string, List<string>> idiom in idioms)
        {
            string phrase = "";
            foreach (string word in idiom.Value)
            {
                phrase = phrase + " " + word;
            }
            Console.WriteLine($"{idiom.Key}: {phrase}");
        }
        Console.WriteLine("-----------------------------------------------");

        // Take the following JavaScript data structure that represents car sales and convert it to C# Lists and Dictionaries. Make sure that all of your variable names conform to the C# standard of Camel Case instead of Snake Case.
        Dictionary<string, string> vehicle = new Dictionary<string, string>();

        vehicle.Add("year", "2008");
        vehicle.Add("model", "Damfresh");
        vehicle.Add("make", "Biotraxquote");
        vehicle.Add("color", "Sky Magenta");

        Dictionary<string, string> salesId = new Dictionary<string, string>();

        salesId.Add("salesId", "ecb1c841-1a43-4a7c-896e-712d2ec39c71");

        Dictionary<string, string> salesAgent = new Dictionary<string, string>();
        salesAgent.Add("mobile", "(896) 478-6975");
        salesAgent.Add("last_name", "Botsford");
        salesAgent.Add("first_name", "Shaina");
        salesAgent.Add("emails", "beatae_sonny@hotmail.com or shaina@aol.com");

        Dictionary<string, string> purchaseDate = new Dictionary<string, string>();
        purchaseDate.Add("purchase_date", "2017-11-15");

        Dictionary<string, string> grossProfit = new Dictionary<string, string>();
        grossProfit.Add("gross_profit", "871.26");

        Dictionary<string, string> credit = new Dictionary<string, string>();

        credit.Add("credit_provider", "J.P.Morgan Chase & Co");
        credit.Add("account", "601109582720302");

        List<Dictionary<string, string>> Vehicles = new List<Dictionary<string, string>>(){
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


        // Use the list of planets you created in the previous chapter or create a new one with all eight planets.
        List<string> planetList = new List<string>(){
            "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"};

        // Create a list containing KeyValuePairs. Each KeyValuePair will hold the name of a spacecraft that we have launched, and the name of a planet that it has visited. The key of the KeyValuePair will be the probe name, and the value will be the planet it visited.
        List<KeyValuePair<string, string>> probe = new List<KeyValuePair<string, string>>();

        List<KeyValuePair<string, string>> probeDestinations = new List<KeyValuePair<string, string>>()
            {
new KeyValuePair<string, string>("Viking 1", "Mars"),
new KeyValuePair<string, string>("Mariner 10","Mercury"),
new KeyValuePair<string, string>("Venera 1","Venus"),
new KeyValuePair<string, string>("Mariner 3","Mars"),
new KeyValuePair<string, string>("Pioneer 10","Jupiter"),
new KeyValuePair<string, string>("Voyager 2","Uranus"),
new KeyValuePair<string, string>("Voyager 1","Saturn")


            };

        // Iterate over probeDestinations, and inside that loop, iterate over the list of dictionaries. Write to the console, for each planet, which probes have visited it.

        // Iterate planets
        foreach (string planet in planetList)
        {
            // List to store probes that visited the planet
            List<string> matchingProbes = new List<string>();


            // Iterate probeDestinations
            foreach (KeyValuePair<string, string> pair in probeDestinations)
            {
                /*
                    Does the current probe's destination
                    match the value of the `planet` variable?
                    If so, add it to the list.
                */
                if (planet == pair.Value)
                {
                    matchingProbes.Add(pair.Key);
                }
            }

            /*
                Use String.Join(",", matchingProbes) as part of the
                solution to get the output below. It's the C# way of
                writing `array.join(",")` in JavaScript.
            */
            string probeString = string.Join(", ", matchingProbes);

            Console.WriteLine($"{planet}: {probeString}");
        }

        Console.WriteLine("-----------------------------------------------");

        // A block of publicly traded stock has a variety of attributes, we'll look at a few of them. A stock has a ticker symbol and a company name. Create a simple dictionary with ticker symbols and company names in the Main method.

        Dictionary<string, string> stocks = new Dictionary<string, string>();
        stocks.Add("GM", "General Motors");
        stocks.Add("CAT", "Caterpillar");
        stocks.Add("BTC", "Bitcoin");
        stocks.Add("AMZ", "Amazon");
        stocks.Add("GOO", "Google");
        stocks.Add("YAH", "Yahoo");
        stocks.Add("NF", "NewForce");
        stocks.Add("C10", "Core 10");



        // To find a value in a Dictionary, you can use square bracket notation much like JavaScript object key lookups.

        string GM = stocks["GM"];

        // Next, create a data structure to record how many stock purchases were made for each company over time. In this Dictionary, the key will be the ticker symbol, and the value will be a collection of numbers representing how much the investor paid.
        // {
        //     "AAPL": [1214.90, 2881.95],
        //     "GM": [4892.12],
        //     "MSFT": [934.21, 9025.23, 4013.89],
        //     "TWTR": [180.44, 298.01, 9092.45],
        // }

        // How would you define this structure using C# data types? Once you've determined how to define the data structure, you need to add purchases for a few companies. Start with three companies, and 1-3 purchases for each one.

        Dictionary<string, List<double>> portfolio = new Dictionary<string, List<double>>(){

{stocks["GM"], new List<double>(){1214.90, 2154.23}},
{stocks["CAT"], new List<double>(){6524.8, 1234.56}},
{stocks["BTC"], new List<double>(){5687.30, 2654.25, 5897.2}},
{stocks["YAH"], new List<double>(){1214.90, 2154.23, 263.21}},
{stocks["NF"], new List<double>(){1214.90, 2154.23, 1247.8}},
{stocks["C10"], new List<double>(){1111.22, 2154.23, 1245.6}},
{stocks["AMZ"], new List<double>(){2223.90, 1245.78, 3524.1}}

};

        // Once you've added your stocks and purchases, produce a total ownership report that computes the total amount of money spent by the investor on each stock. Note that the final report has the full company name, not the ticker symbol. You must use the ticker symbol and square bracket notation to get the full company name from the stocks Dictionary.



        foreach (var stock in portfolio)
        {
            double totalSpend = 0;
            stock.Value.ForEach(value => totalSpend += value);
            Console.WriteLine($"Investor has spent a total of {totalSpend} on the stock for {stock.Key}");
        }
        Console.WriteLine("-----------------------------------------------");










        // end of Main
    }
}


