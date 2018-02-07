using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class GroupUpdateTests : TestBase
    {
        [Test]
        public void GroupUpdateTest()
        {
            app.Navigator.GoToGroupPage();
            app.Groups.SelectGroup(1);
            app.Buttons.ClickEditButton();
            GroupData newgroup = new GroupData("aa1");
            newgroup.GroupHeader = "dd1";
            newgroup.GroupFooter = "cc1";
            app.Buttons.ClickSubmitButton();
            app.Auth.Logout();
        }
    }
}
