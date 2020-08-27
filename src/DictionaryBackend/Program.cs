using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Web.Http.Cors;

namespace Dictionary
{
    class Program
    {
        static async Task Main(string[] args)
    	{
	// 		EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
    // config.EnableCors(cors);
            var client = new HttpClient();
        	client.BaseAddress = new Uri("https://wordsapiv1.p.rapidapi.com");
        	client.DefaultRequestHeaders.Add("X-Mashape-Key", "YourKey");
 
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
