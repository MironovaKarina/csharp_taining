using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactDeleteTests : AuthTestBase
    {

        [Test]
        public void ContactDeleteTest()
        {
            ContactData newcontact = new ContactData("Name","Lastname");
            if (!app.Cont.IsElementPresent(By.Name("selected[]")))
            {
                app.Cont.Add(newcontact);
            }

            List<ContactData> oldContact = app.Cont.GetContactlist();

            app.Cont.Remove(1);

            List<ContactData> newContact = app.Cont.GetContactlist();
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);

        }
    }
}
