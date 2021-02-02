using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TeaHouse.ConsoleClient
{
    public class Extra
    {
        public int Id { get; set; }
        public string ExtraName { get; set; }
        public string Category { get; set; }
        public string Allergen { get; set; }
        public bool Available { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"ID= {Id}\tCATEGORY={Category} \tNAME= {ExtraName}\tALLERGEN= {Allergen}\tAVAILABLE= {Available}\tPrice= {Price}";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:53083/api/ExtrasApi/";
            Console.WriteLine("WAITING...");
            Console.ReadLine();

            using (HttpClient client = new HttpClient())
            {
                string json = client.GetStringAsync(url + "all").Result;
                var extraList = JsonConvert.DeserializeObject<List<Extra>>(json);
                foreach (var item in extraList) Console.WriteLine(item);
                Console.ReadLine();

                Dictionary<string, string> postData;
                string response;

                postData = new Dictionary<string, string>();
                postData.Add(nameof(Extra.Category), "MILKTYPE");
                postData.Add(nameof(Extra.ExtraName), "SOYAMILK");
                postData.Add(nameof(Extra.Price), "200");

                response = client.PostAsync(url + "add", new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("ADD: " + response);
                Console.WriteLine("ALL: " + json);
                Console.ReadLine();

                int extraID = JsonConvert.DeserializeObject<List<Extra>>(json).Single(x => x.ExtraName == "SOYAMILK").Id;
                postData = new Dictionary<string, string>();
                postData.Add(nameof(Extra.Id), extraID.ToString());
                postData.Add(nameof(Extra.Category), "MILKTYPE");
                postData.Add(nameof(Extra.ExtraName), "SOYAMILK");
                postData.Add(nameof(Extra.Available), "true");
                postData.Add(nameof(Extra.Price), "150");

                response = client.PostAsync(url + "mod",
                    new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
                Console.WriteLine("MOD: " + response);
                Console.WriteLine("ALL: " + client.GetStringAsync(url + "all").Result);
                Console.ReadLine();

                Console.WriteLine("DEL: " + client.GetStringAsync(url + "del/" + extraID).Result);
                Console.WriteLine("ALL: " + client.GetStringAsync(url + "all").Result);
                Console.ReadLine();
            }
        }
    }
}
