using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddContact : AuthTestBase
    {

        [Test]
        public void TheAddContactTest()
        {
            ContactData contact = new ContactData("Karina", "Mironova");

            List<ContactData> oldContact = app.Cont.GetContactlist();

            app.Navigator.GoToHomePage();
            app.Cont
                .InitContactCreation()
                .FillContactInformation(contact)
                .SubmitContactCreation();

            List<ContactData> newContact = app.Cont.GetContactlist();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

        }
    }
}
