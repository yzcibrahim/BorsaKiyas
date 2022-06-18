
using CommonLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AltinFiyatlari
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var islem = Console.ReadLine();

            HttpClient client = new HttpClient();
            var res= client.GetAsync("http://localhost:55749/api/Banka");
            var resp = res.Result.Content.ReadAsStringAsync();
            var liste = JsonConvert.DeserializeObject<List<BankaViewModel>>(resp.Result);
           

        }
    }
}
