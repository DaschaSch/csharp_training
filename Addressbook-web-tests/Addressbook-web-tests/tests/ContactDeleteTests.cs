﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDeleteTests : AuthTestBase
    {
        
        [Test]
        public void ContactDeleteTest()
        {
            app.Contacts.Remove(1);
        }
     }
}
