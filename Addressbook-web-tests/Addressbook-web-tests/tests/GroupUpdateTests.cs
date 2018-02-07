using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupUpdateTests : TestBase
    {
        [Test]
        public void GroupUpdateTest()
        {
            GroupData newgroup = new GroupData("aa1");
            newgroup.GroupHeader = "dd1";
            newgroup.GroupFooter = "cc1";

            app.Groups.Modify(1, newgroup);

        }
    }
}
