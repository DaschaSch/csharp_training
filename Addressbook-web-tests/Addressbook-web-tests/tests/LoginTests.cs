using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWtihValidCredentials()
        {
            //arrange
            app.Auth.Logout();
            //action
            LoginData account = new LoginData("admin", "secret");
            app.Auth.Login(account);
            //assert
            Assert.IsTrue(app.Auth.IsLoggedIn());
        }
        [Test]
        public void LoginWtihInvalidCredentials()
        {
            app.Auth.Logout();

            LoginData account = new LoginData("admin", "12342");
            app.Auth.Login(account);

            Assert.IsFalse(app.Auth.IsLoggedIn());
        }

    }
}
