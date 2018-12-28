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
                ContactData newData = new ContactData("XXX", "YYY");

            List<ContactData> oldContact = app.Cont.GetContactlist();
            ContactData oldData = oldContact[0];

            app.Cont.Modify(0,newData);

            List<ContactData> newContact = app.Cont.GetContactlist();
            oldContact[0].Lastname = newData.Lastname;
            oldContact[0].Firstname = newData.Firstname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
