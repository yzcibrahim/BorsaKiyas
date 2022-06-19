using CommonLib;
using OpenQA.Selenium;
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
    public class IsBankCrawler :BaseCrawler, ICrawler
    {
        
        public IsBankCrawler(BankaViewModel banka):base(banka)
        {
        }
       
        protected override void DoOps(ChromeDriver driver)
        {
            driver.Navigate().GoToUrl(_banka.Url);

            var altinElement = driver.FindElements(By.ClassName("i-bk-area")).Last();

            var text = altinElement.Text;

            var alisText = altinElement.FindElement(By.ClassName("i-bk-usd-a-v")).Text;
            var satisText = altinElement.FindElement(By.ClassName("i-bk-usd-s-v")).Text;

            var alisD = Convert.ToDouble(alisText);
            var satisD = Convert.ToDouble(satisText);
            PostToApi(alisD, satisD);
        }

       
    }
}
