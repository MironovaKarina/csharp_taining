using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] s = new string[] { "I", "want", "to", "sleep" };
            foreach (string element in s)
            {
                System.Console.Out.Write(element + "\n");
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            IWebDriver driver=null;
            int attempt = 0;
            {
                System.Threading.Thread.Sleep(1000);
            } while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 6) ;

        }
    }
}
