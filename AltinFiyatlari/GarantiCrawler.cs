using CommonLib;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AltinFiyatlari
{
    public class GarantiCrawler:BaseCrawler,ICrawler
    {
        public GarantiCrawler(BankaViewModel banka):base(banka)
        {
            
        }

        protected override void DoOps(ChromeDriver driver)
        {
         
            driver.Navigate().GoToUrl(_banka.Url);

            try
            {
                // IWebElement btnOkudum = driver.FindElement(By.ClassName("btn-alpha"));
                //IWebElement btnOkudum=driver.FindElement(By.XPath("//<button>[text()=[contains(.,'OKUDUM, ONAYLIYORUM')]]"));
                //  var modalElement = driver.FindElement(By.ClassName("modal-dialog"));

                Thread.Sleep(1000);
                var buttonOkudum = driver.FindElements(By.ClassName("btn-container"))[1];
                // buttons.Where(c=>c.GetAttribute())
                buttonOkudum.Click();
            }
            catch (Exception ex)
            {
            }

            IWebElement elem1 = driver.FindElements(By.ClassName("js-select-product"))[1];

            string text = elem1.Text;
            elem1.Click();

            IWebElement alis = driver.FindElement(By.ClassName("rate"));
            var alistext = alis.Text;
            var fiyatElement = driver.FindElement(By.ClassName("product-detail"));
            var satis = fiyatElement.FindElements(By.ClassName("pull-right"))[0];
            var satisText = satis.FindElement(By.TagName("feed-listener-cell")).Text;

            //   Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");


            alistext = alistext.Replace(".", "");
            alistext = alistext.Replace(",", ".");
            satisText = satisText.Replace(".", "");
            satisText = satisText.Replace(",", ".");

            double alisD = Convert.ToDouble(alistext);
            double satisD = Convert.ToDouble(satisText);

            PostToApi(alisD, satisD);



        }


        public void CrawleOld()
        {
            HttpWebRequest r = (HttpWebRequest)WebRequest.Create("https://www.hurriyet.com.tr/");
            r.Method = "Get";
            HttpWebResponse res = (HttpWebResponse)r.GetResponse();
            Stream sr = res.GetResponseStream();
            StreamReader sre = new StreamReader(sr);

            string s = sre.ReadToEnd();

            int startindex = s.IndexOf("hot-agenda__list");
            s = s.Substring(startindex);

            s = s.Substring(s.IndexOf("title"), s.IndexOf("class") - s.IndexOf("title"));

            s = s.Remove(0,6);
        }
    }


}
