using CommonLib;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AltinFiyatlari
{
    public abstract class BaseCrawler : ICrawler
    {
        protected BankaViewModel _banka;
        bool cancel = false;

        public void setCCancel()
        {
            cancel = true;
        }
        public BaseCrawler(BankaViewModel banka)
        {
            _banka = banka;
        }
        public virtual async Task<bool> Crawle()
        {

            using (var driver = new ChromeDriver())
            {
                while (true)
                {
                    Console.WriteLine($"{_banka.Ad} crawle ediliyor");
                    Thread.Sleep(5000);
                    if (!cancel)
                        try
                        {
                            DoOps(driver);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("hata oluştu:" + ex.Message);
                        }

                }
            }


        }

        protected abstract void DoOps(ChromeDriver driver);

        protected void PostToApi(double alisD, double satisD)
        {
            HttpClient client = new HttpClient();
            //  client.BaseAddress = new Uri("http://localhost:55749");

            ExchangeRate model = new ExchangeRate()
            {
                BankaId = _banka.Id,
                Alis = alisD,
                Satis = satisD,
                Tarih = DateTime.Now
            };

            Console.WriteLine($"KAyıtlar alındı post ediliyor:banka:{_banka.Ad} alis:{model.Alis} satis:{model.Satis}");

            var response = client.PostAsJsonAsync("http://localhost:55749/api/Exhange", model);
        }
    }
}
