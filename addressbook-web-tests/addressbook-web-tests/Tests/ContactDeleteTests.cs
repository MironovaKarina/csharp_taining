﻿using System;
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
            app.Cont.Remove(1);

        }
    }
}