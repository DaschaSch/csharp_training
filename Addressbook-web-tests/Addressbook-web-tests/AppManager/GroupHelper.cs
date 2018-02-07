using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
   public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager)
            : base(manager)
        { }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(v);
            manager.Buttons.ClickDeleteButton();
            manager.Navigator.GoToGroupPage();
            return this;
        }

        internal GroupHelper Modify(int v, GroupData newgroup)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(v);
            ClickEditButton();
            ClickUpdateButton();
            manager.Auth.Logout();
            return this;
        }

        public GroupHelper Create(GroupData newgroup)
        {
            manager.Navigator.GoToGroupPage();
            manager.Buttons.ClickNewButton();
            CreateNewGroup(newgroup);
            manager.Buttons.ClickSubmitButton();
            manager.Auth.Logout();
            return this;
        }
        public GroupHelper CreateNewGroup(GroupData newgroup)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(newgroup.GroupName);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(newgroup.GroupHeader);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(newgroup.GroupFooter);
            return this;
        }
        public GroupHelper ClickEditButton()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper ClickUpdateButton()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
    }
}
