using System;
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

            app.Groups.GroupCreationIfNotPresent(newgroup);
            app.Groups.Remove(1);

        }
    }
}
