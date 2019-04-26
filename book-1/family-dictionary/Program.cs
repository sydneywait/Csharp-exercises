using System;
using System.Collections.Generic;

namespace family_dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
// Define a Dictionary that contains information about several members of your family. Use the following example as a template.

Dictionary<string, Dictionary<string, string>> myFamily = new Dictionary<string, Dictionary<string, string>>();

myFamily.Add("sister", new Dictionary<string, string>(){
    {"name", "Shannon"},
    {"age", "40"}
});

myFamily.Add("brother", new Dictionary<string, string>(){
    {"name", "Logan"},
    {"age", "44"}
});
myFamily.Add("mother", new Dictionary<string, string>(){
    {"name", "Connie"},
    {"age", "69"}
});
myFamily.Add("father", new Dictionary<string, string>(){
    {"name", "Ralph"},
    {"age", "67"}
});


// Next, iterate over each item in myFamily and produce the following output. Remember that you can use square bracket notation to get to the value of a key, and that a dictionary has a Key and a Value property.

foreach(KeyValuePair<string, Dictionary<string, string>> familyMember in myFamily)
{


Console.WriteLine($"{familyMember.Value["name"]} is my {familyMember.Key} and is {familyMember.Value["age"]} years old");
}

// Example output: Krista is my sister and is 42 years old

        }
    }
}
