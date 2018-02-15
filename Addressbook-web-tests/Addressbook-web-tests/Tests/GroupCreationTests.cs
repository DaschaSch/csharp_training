using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData newgroup = new GroupData("aca");
            newgroup.GroupHeader = "ddd";
            newgroup.GroupFooter = "ccc";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(newgroup);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newgroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);


        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData newgroup = new GroupData("");
            newgroup.GroupHeader = "";
            newgroup.GroupFooter = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(newgroup);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newgroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData newgroup = new GroupData("a'a");
            newgroup.GroupHeader = "";
            newgroup.GroupFooter = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(newgroup);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newgroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}

