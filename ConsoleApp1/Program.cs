using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {



        static void Main(string[] args)
        {
            string[] values =
                             {
                                "GeoMeta",
                                "Государственная система обеспечения градостроительной деятельности",
                                "Городская аналитика",
                                "Другие наши проекты "
                            };

            Test test = new Test();
            ArrayList valuesH1H2 = new ArrayList();
            ArrayList valuesH1H2Result = new ArrayList();

            valuesH1H2Result.AddRange(test.Test3());
            valuesH1H2.AddRange(values);
            foreach (string elem in valuesH1H2Result)
            {
                Console.WriteLine($"result value ->> {elem}");
            }


            //test.test2();
            //test.Test1();
            //test.Test3();
        }


    }

    class Test
    {
        IWebDriver driver = new ChromeDriver("C:\\Users\\SUN\\Downloads\\chromedriver_win32");
        IWebElement webElement;
        private string urlGems = "https://gemsdev.ru";



        //public void Test1()
        //{
        //    valuesH1H2.AddRange(values);

        //    driver.Manage().Window.Maximize();
        //    driver.Navigate().GoToUrl(urlGems);
        //    webElement = driver.FindElement(By.LinkText("Продукты"));

        //    webElement.Click();

        //    //int ScrollHeight = 0;
        //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        //    for(int i = 0; i<4; i++) 
        //    { 
        //            var newScrollHeight = js.ExecuteScript(
        //                "window.scrollBy(0,600)"
        //                );
        //            Thread.Sleep(1000);
        //    }
        //    List<IWebElement> webH2 = driver.FindElements(By.CssSelector("h1, h2")).ToList();

        //    ArrayList valuesH1H2New = new ArrayList();
        //    for (int i = 0; i < webH2.Count; i++)
        //    {
        //        // string res = webH2[i].Text;
        //        valuesH1H2New.Add(webH2[i].Text);
        //        Console.WriteLine($"\nh2 {i} -> {webH2[i].Text}");

        //    }

        //    //valuesH1H2.Contains(webH2);
        //    for (int i=0; i < webH2.Count; i++)
        //    {

        //        Console.WriteLine($"in ArrayList -> {valuesH1H2[i]} - {valuesH1H2New[i]} <- in resArray");
        //        Console.ReadLine();
        //    }
        //    // string res = driver.FindElement(By.CssSelector("h1, h2")).Text;
        //    // Console.WriteLine($"text in h is -> {res}");
        //    driver.Quit();

        //}

        //public void test2()
        //{
        //    string findUrl = "https://refactoring.guru/ru/design-patterns/csharp";
        //    driver.Manage().Window.Maximize();
        //    driver.Navigate().GoToUrl(findUrl);

        //    string res = driver.FindElement(By.CssSelector("body > div.body-holder > main > div > div > div.dp-text > h2")).Text;
        //    Console.WriteLine($"text in h is -> {res}");
        //    driver.Quit();
        //    //driver.FindElement(By.XPath());

        //}


        public ArrayList Test3()
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
                    "window.scrollBy(0,500)"
                    );
                Thread.Sleep(1000);
            }

            List<IWebElement> webH2 = driver.FindElements(By.CssSelector("h1,h2")).ToList();
            ArrayList valuesH1H2New = new ArrayList();

            for (int i = 0; i < webH2.Count; i++)
            {
                valuesH1H2New.Add(webH2[i].Text);
            }
            foreach (string elem in valuesH1H2New)
            {
                Console.WriteLine($"In test function -> {elem}");
            }
            driver.Quit();
            return valuesH1H2New;


        }
    }

}