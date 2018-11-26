using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests.Tests
{
    [TestClass]
    public class UnitTest2
    {

        [TestMethod]
        public void TestMethod1()
        {
            double total = 90;
            bool vipClient = false;

            if (total>1000 || vipClient)
            {
                total = total * 0.9;
                System.Console.Out.Write("Скидка 10%, общая сумма " + total);
            }
        }
    }
}
