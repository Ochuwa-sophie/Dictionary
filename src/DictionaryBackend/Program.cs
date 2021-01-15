using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;


namespace Dictionary
{
    class Program
    {
        static async Task Main(string[] args)
    	{
			
            var client = new HttpClient();
        	client.BaseAddress = new Uri("https://wordsapiv1.p.rapidapi.com");
        	client.DefaultRequestHeaders.Add("X-Mashape-Key", "1bc55635edmsh5d5800c31204366p15f03djsneb5918e71ce9");
 
        	Console.WriteLine("Enter word to look up!");
            var wordToDefine = Console.ReadLine();

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
