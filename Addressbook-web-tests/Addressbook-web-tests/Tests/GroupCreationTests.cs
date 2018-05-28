using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for(int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    GroupHeader = GenerateRandomString(100),
                    GroupFooter = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromJSONFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"group.json"));
        }

        [Test, TestCaseSource("GroupDataFromJSONFile")]
        public void GroupCreationTest(GroupData newgroup)
        {

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(newgroup);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

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

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newgroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}

