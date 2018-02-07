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

        public GroupHelper(IWebDriver driver)
            : base(driver)
        { }
        public void CreateGroup(GroupData newgroup)
        {
            driver.FindElement(By.Name("new")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(newgroup.GroupName);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(newgroup.GroupHeader);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(newgroup.GroupFooter);
        }
        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

        public void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }
    }
}
