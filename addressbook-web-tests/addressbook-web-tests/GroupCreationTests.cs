﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupsPage();
            InitNewGroup();
            GroupData group = new GroupData("kkk");
            group.Header = "mmm";
            group.Footer = "rrr";
            FillGroupForm(group);
            Submit();
            ReturnToGroupsPage();
        }
    }
}
