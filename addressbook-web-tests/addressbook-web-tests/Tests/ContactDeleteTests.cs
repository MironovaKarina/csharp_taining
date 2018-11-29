using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactDeleteTests : TestBase
    {

        [Test]
        public void ContactDeleteTest()
        {
            List<ContactData> oldContact = app.Cont.GetContactist();

            app.Cont.Remove(0);

            List<ContactData> newContact = app.Cont.GetContactist();
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);

        }
    }
}
