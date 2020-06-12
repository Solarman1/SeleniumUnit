using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleApp1
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Test test = new Test();
            test.test2();
            test.Test1();
        }

      
    }

    class Test 
    {
        IWebDriver driver = new ChromeDriver("C:\\Users\\SUN\\Downloads\\chromedriver_win32");
        IWebElement webElement;
        private string urlGems = "https://gemsdev.ru";
        public void Test1()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(urlGems);
            webElement = driver.FindElement(By.LinkText("Продукты"));

            webElement.Click();

            //List <IWebElement> h2elements = driver.FindElement(By.CssSelector(".container h2")).ToList();
            // List <IWebElement> webH2 = driver.FindElements(By.CssSelector("body > section.my-150 > div > div > div.col-12.col-md-6.fadeInDown > h1")).ToList();
            //// List<IWebElement> webH3 = driver.FindElements(By.CssSelector(".col-12 p ")).ToList();

            //for (int i = 0; i < webH2.Count; i++)
            //{
            //   // string res = webH2[i].Text;
            //    Console.WriteLine($"\nh2 {i} -> {webH2[i].Text}");

            //}

            //webElement = driver.FindElement(By.XPath("/html/body/section[2]/div[2]/div[1]/div[2]/h2/text()"));
            
            
            string res = driver.FindElement(By.CssSelector("body > section.my-150 > div > div > div.col-12.col-md-6.fadeInDown > h1")).Text;
            Console.WriteLine($"h2 is -> {res}");
            driver.Quit();

        }

        public void test2()
        {
            string findUrl = "https://xn--c1aaceme9acfqh.xn--p1ai/";
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(urlGems);
            driver.FindElement(By.XPath());
            
        }
    }

}
