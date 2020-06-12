using System;
using System.Collections.Generic;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
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
                                "Государственная система обеспечения градостроительной деятельности",
                                "Городская аналитика",
                                "Другие наши проекты "
        };

        string Test1()
        {
            string res;
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(urlGems);
            webElement = driver.FindElement(By.LinkText("Продукты"));

            webElement.Click();

            res = driver.FindElement(By.CssSelector("h2")).Text;

            //List<IWebElement> webH2 = driver.FindElements(By.CssSelector("body > section.my-150 > div > div > div.col-12.col-md-6.fadeInDown > h1")).ToList();
            //for (int i = 0; i < webH2.Count; i++)
            //{
            //    res = webH2[i].Text;  
            //}

            driver.Quit();
            return res;
        }

        [Fact]
        public void passingTest()
        {

         Test1();
           
         Assert.Equal(values[0], Test1());
            
        }

        //[Fact]
        //public void faiillingTest()
        //{
            
        //}

    }
}
