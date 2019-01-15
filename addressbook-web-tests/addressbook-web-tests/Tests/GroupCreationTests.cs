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
using System.Linq;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i=0; i<5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        /* public static IEnumerable<GroupData> GroupDataFomCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines =  File.ReadAllLines(@"group.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }  */


        public static IEnumerable<GroupData> GroupDataFomXmlFile()
        {
            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>))
                   .Deserialize(new StreamReader(@"group.xml"));
             
        }

        public static IEnumerable<GroupData> GroupDataFomJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"group.json"));
        }


        [Test, TestCaseSource("GroupDataFomJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
          /*  GroupData group = new GroupData("kkk");
            group.Header = "mmm";
            group.Footer = "rrr";  */

            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
        /*  [Test]
          public void EmptyGroupCreationTest()
          {
              GroupData group = new GroupData("");
              group.Header = "";
              group.Footer = "";

              List<GroupData> oldGroups = app.Groups.GetGroupList();

              app.Groups.Create(group);

              Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

              List<GroupData> newGroups = app.Groups.GetGroupList();
              Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);

          } */

        [Test]
        public void TestDBConnectivity()
        {
            /* DateTime start = DateTime.Now;
             List<GroupData> fromUi = app.Groups.GetGroupList();
             DateTime end = DateTime.Now;
             System.Console.Out.WriteLine(end.Subtract(start));

             start = DateTime.Now;
             List<GroupData> fromDb = GroupData.GetAll();
             end = DateTime.Now;
             System.Console.Out.WriteLine(end.Subtract(start));  */

           foreach (ContactData contact in GroupData.GetAll()[0].GetContacts())
            {
                System.Console.Out.WriteLine(contact);
            }
        }
    }
}
