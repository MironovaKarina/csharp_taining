using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactModifyTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
                ContactData newData = new ContactData("WWW", "YYY");

            List<ContactData> oldContact = app.Cont.GetContactlist();

            app.Cont.Modify(newData);

            List<ContactData> newContact = app.Cont.GetContactlist();
            oldContact[0].lastname = newData.lastname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
