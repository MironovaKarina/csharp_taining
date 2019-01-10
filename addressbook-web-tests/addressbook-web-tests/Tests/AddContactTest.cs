using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddContact : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30)));
            }
            return contacts;
        }

        [Test, TestCaseSource("ContactDataFomJsonFile")]
        public void TheAddContactTest(ContactData contact)
        {
            List<ContactData> oldContact = app.Cont.GetContactlist();

            app.Navigator.GoToHomePage();
            app.Cont
                .InitContactCreation()
                .FillContactInformation(contact)
                .SubmitContactCreation();

        /*    List<ContactData> newContact = app.Cont.GetContactlist();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact); */

        }

        public static IEnumerable<ContactData> ContactDataFomXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                   .Deserialize(new StreamReader(@"contact.xml"));

        }

        public static IEnumerable<ContactData> ContactDataFomJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contact.json"));
        }
    }
}
