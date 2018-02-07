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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new LoginData("admin", "secret"));
            app.Navigator.GoToGroupPage();
            GroupData newgroup =new GroupData("aaa");
            newgroup.GroupHeader = "ddd";
            newgroup.GroupFooter = "ccc";
            app.Groups.CreateGroup(newgroup);
            app.Buttons.ClickSubmitButton();
            app.Auth.Logout();
        }
    }
}

