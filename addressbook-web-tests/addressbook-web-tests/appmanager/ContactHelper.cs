using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
   public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Modify(ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(1);
            EditContact();
            FillContactInformation(newData);
            UpdateContact();
            return this;
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("(//*[@id='content']/form[1]/input[1])")).Click();
            return this;
        }

        public ContactHelper EditContact()
        {
            driver.FindElement(By.XPath("(//*[@id='maintable']/tbody/tr[2]/td[8]/a/img)")).Click();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            RemoveContact();
            driver.SwitchTo().Alert().Accept();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//*[@id='content']/form[2]/div[2])")).Click();
            return this;
        }

        public ContactHelper SelectContact(int p)
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactInformation(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Notes:'])[1]/following::input[1]")).Click();
            return this;
        }
    }
}
