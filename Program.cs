using System;
using System.Threading.Tasks;
using System.Net.Http;
// using Newtonsoft.Json;
using System.Text.Json;

namespace Dictionary
{
    class Program
    {
        static async Task Main(string[] args)
    	{
            var client = new HttpClient();
        	client.BaseAddress = new Uri("https://wordsapiv1.p.rapidapi.com");
        	client.DefaultRequestHeaders.Add("X-Mashape-Key", "5440b3736bmshd71edb6b5891126p1644f2jsnda3c418bc085");
 
        	var wordToDefine = "Bicycle";
 
        	try
        	{
            	var response = await client.GetAsync("/words/" + wordToDefine);
                response.EnsureSuccessStatusCode();
            	var responseString = await response.Content.ReadAsStringAsync();
 
            	DefinitionResult definitionObject = JsonSerializer.Deserialize<DefinitionResult>(responseString);
 
            	foreach (var definition in definitionObject.results)
      	      {
                	Console.WriteLine("--------------------------------------------------------");
                    Console.WriteLine(definition.definition);
                    Console.WriteLine(definition.partOfSpeech);
                	Console.WriteLine("SYNONYMS");
                	foreach (var synonyms in definition.synonyms)
                	{
                        Console.WriteLine(synonyms);
                	}
            	}
            	
        	}
        	catch (Exception e)
        	{
            	Console.WriteLine("An error occurred! Error Message: " + e.Message);
        	}
    	}
    }
}
