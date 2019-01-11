using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Cont.GetContactInformationFromTable(0);
            ContactData fromForm = app.Cont.GetContactInformationFromEditForm(0);


            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestContactInformationDetails()
        {
            ContactData fromForm = app.Cont.GetContactInformationFromEditForm(0);
            string fromDetails = app.Cont.GetContactInformationFromDetails(0);

            Assert.AreEqual(fromDetails, fromForm.AllContent);
        }
    }
}
