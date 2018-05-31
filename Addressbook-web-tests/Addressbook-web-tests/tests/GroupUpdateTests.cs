using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupUpdateTests : GroupTestBase
    {
        [Test]
        public void GroupUpdateTest()
        {
            GroupData newgroup = new GroupData("aa1");
            newgroup.GroupHeader = "dd1";
            newgroup.GroupFooter = "cc1";

            app.Groups.GroupCreationIfNotPresent(newgroup);

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(oldData, newgroup);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Id = newgroup.Id;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                if(group.Id == oldData.Id)
                {
                    Assert.AreEqual(newgroup.GroupName, group.GroupName);
                }
            }
        }
    }
}
