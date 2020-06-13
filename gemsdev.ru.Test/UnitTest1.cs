using System;
using System.Collections.Generic;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Collections;
using System.Threading;
using System.Net.Http.Headers;

namespace gemsdev.ru.Test
{
    public class UnitTest1
    {
        private IWebDriver driver = new ChromeDriver("C:\\Users\\SUN\\Downloads\\chromedriver_win32");
        private IWebElement webElement;


        private string urlGems = "https://gemsdev.ru";
        private string[] values =
        {
        "GeoMeta",
        "Государственная система обеспечения градостроительной деятельности",
        "Городская аналитика",
        "Другие наши продукты"
        };
        ArrayList valuesH1H2 = new ArrayList();
        ArrayList valuesH1H2Result = new ArrayList();


        ArrayList Test1()
        {

            string[] res = { };
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(urlGems);
            webElement = driver.FindElement(By.LinkText("Продукты"));

            webElement.Click();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            for (int i = 0; i < 4; i++)
            {
                var newScrollHeight = js.ExecuteScript(
                    "window.scrollBy(0,600)"
                    );
                Thread.Sleep(1000);
            }

            List<IWebElement> webH2 = driver.FindElements(By.CssSelector("h1,h2")).ToList();
            ArrayList valuesH1H2New = new ArrayList();

            for (int i = 0; i < webH2.Count; i++)
            {
                valuesH1H2New.Add(webH2[i].Text);
            }

            driver.Quit();
            return valuesH1H2New;
        }

        [Fact]
        public void passingTest()
        {
            valuesH1H2.AddRange(values);
            valuesH1H2Result.AddRange(Test1());

            for (int i = 0; i < valuesH1H2.Count; i++)
            {
                Assert.Equal(valuesH1H2[i], valuesH1H2Result[i]);
            }
        }

        //[Fact]
        //public void faiillingTest()
        //{

        //}

    }
}
