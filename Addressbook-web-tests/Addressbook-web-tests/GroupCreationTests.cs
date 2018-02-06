﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new LoginData("admin", "secret"));
            GoToGroupPage();
            GroupData newgroup =new GroupData("aaa");
            newgroup.GroupHeader = "ddd";
            newgroup.GroupFooter = "ccc";
            CreateGroup(newgroup);
            ClickSubmitButton();
            Logout();
        }
    }
}

