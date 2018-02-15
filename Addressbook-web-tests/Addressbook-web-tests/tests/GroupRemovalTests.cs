﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            GroupData newgroup = new GroupData("aaa");
            newgroup.GroupHeader = "ddd";
            newgroup.GroupFooter = "ccc";


            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.GroupCreationIfNotPresent(newgroup);
            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
