using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData newgroup = new GroupData("aaa");
            newgroup.GroupHeader = "ddd";
            newgroup.GroupFooter = "ccc";

            app.Groups.Create(newgroup);
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData newgroup = new GroupData("");
            newgroup.GroupHeader = "";
            newgroup.GroupFooter = "";

            app.Groups.Create(newgroup);

        }
    }
}

