using System.Collections.Generic;
using System.Web.Http.Cors;
// using Microsoft.AspNetCore.Cors;
using System.Console;

namespace Dictionary
{
    

     [EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
    public class Result    {
        public string definition { get; set; } 
        public string partOfSpeech { get; set; } 
        public List<string> synonyms { get; set; }
        public List<string> typeOf { get; set; } 
        public List<string> hasTypes { get; set; } 
        public List<string> derivation { get; set; }
    	public List<string> hasParts { get; set; }

    }

    public class Syllables    {
        public int count { get; set; } 
        public List<string> list { get; set; } 
    }

    public class Pronunciation    {
        public string all { get; set; } 
    }

    public class DefinitionResult  {
        public string word { get; set; } 
        public List<Result> results { get; set; } 
        public Syllables syllables { get; set; } 
        public Pronunciation pronunciation { get; set; } 
        public double frequency { get; set; } 
    }
}
