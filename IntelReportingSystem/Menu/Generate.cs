using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;


namespace IntelReportingSystem.Menu
{
    public class RandomWord
    {
        public string word { get; set; }
    }


    public static class Generate
    {
        static int i=0;
        public static string GenerateCodeName()
        {
            
            string[] arrStr = new string[] { "unintermitted",
                                                "infanticidal",
                                                "onychoptosis",
                                                "americana",
                                                "revolutionists",
                                                "eurasiatic",
                                                "agarita",
                                                "corticosteroid",
                                                "articulata",
                                                "anticoincidence",
                                                "pianissimo",
                                                "antichronism",
                                                "chicken",
                                                "crimson",
                                                "cabbage",
                                                "balloon",
                                                "rainbow",
                                                "running",
                                                "kitchen",
                                                "thunder",
                                                "evening",
                                                "sweater",
                                                "hammers",
                                                "library",
                                                "football",
                                                "trumpet",
                                                "journey",
                                                "brother",
                                                "teacher",
                                                "manager",
                                                "vitamin",};

            string returnWord = arrStr[i];
            i++;
            return returnWord;


            //try
            //{
            //    string ApiKey = "O7WztRjf+bZOruwkQmQZTw==e73PlUeqt14qmI81";
            //    string url = "https://api.api-ninjas.com/v1/randomword";

            //    HttpClient client = new HttpClient();
            //    Console.WriteLine("SAsa");
            //    client.DefaultRequestHeaders.Add("X-Api-Key", ApiKey);

            //    HttpResponseMessage response = await client.GetAsync(url);
            //    string json = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine(json);
            //    Console.WriteLine("hhgh");
            //    RandomWord a = new RandomWord();
            //    //a.word =
            //    RandomWord[]? random_word = JsonSerializer.Deserialize<RandomWord[]>(json);
            //    Console.WriteLine(random_word);
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

        }
    }
}
