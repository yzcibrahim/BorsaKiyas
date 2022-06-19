
using CommonLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

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


            foreach (var banka in liste)
            {
                //reflection
              //  if (banka.Ad != "IsBank") continue;
                ICrawler gc = (ICrawler) Activator.CreateInstance(Type.GetType($"AltinFiyatlari.{banka.Ad}Crawler"), banka);
                Task.Run(gc.Crawle);
               //  gc.Crawle();
            }

            while(true)
            {
                Thread.Sleep(5000);
            }
            //gc.setCCancel();

        }
    }
}
