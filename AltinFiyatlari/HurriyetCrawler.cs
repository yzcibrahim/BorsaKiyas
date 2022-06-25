using CommonLib;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AltinFiyatlari
{
    public class HurriyetCrawler : BaseCrawler, ICrawler
    {
        public HurriyetCrawler(BankaViewModel banka):base(banka)
        {

        }

        protected override void DoOps(ChromeDriver driver)
        {
            driver.Navigate().GoToUrl(_banka.Url);

            var alisText = driver.FindElements(By.ClassName("box"))[0].FindElement(By.ClassName("value")).Text;
            var satisText = driver.FindElements(By.ClassName("box"))[1].FindElement(By.ClassName("value")).Text;

            alisText = alisText.Replace(".", "");
            satisText = satisText.Replace(".", "");

            alisText = alisText.Replace(",", ".");
            satisText = satisText.Replace(".", "");

            PostToApi(Convert.ToDouble(alisText), Convert.ToDouble(satisText));

        }

    }


}
