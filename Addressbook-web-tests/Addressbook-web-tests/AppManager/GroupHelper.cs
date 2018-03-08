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
            groupChache = null;
            return this;

        }

        public GroupHelper Modify(int v, GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(v);
            ClickEditButton();
            CreateNewGroup(group);
            ClickUpdateButton();
            manager.Navigator.GoToGroupPage();
            return this;
        }
        public GroupHelper Create(GroupData newgroup)
        {
            manager.Navigator.GoToGroupPage();

            manager.Buttons.ClickNewButton();
            CreateNewGroup(newgroup);
            manager.Groups.ClickSubmitButton();
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
        //Group creation if group is not present
        public GroupHelper GroupCreationIfNotPresent(GroupData newgroup)
        {
            manager.Navigator.GoToGroupPage();
            if (IsGroupPresent() == false)
            {
                manager.Buttons.ClickNewButton();
                CreateNewGroup(newgroup);
                manager.Groups.ClickSubmitButton();
                manager.Navigator.GoToGroupPage();
            }
            return this;
        }
        public GroupHelper ClickEditButton()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper ClickSubmitButton()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupChache = null;
            return this;
        }
        public GroupHelper ClickUpdateButton()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }
        public bool IsGroupPresent()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
        //private field
        private List<GroupData> groupChache = null;
        public List<GroupData> GetGroupList()
        {
            if(groupChache == null)
            {
                groupChache = new List<GroupData>();
                manager.Navigator.GoToGroupPage();

                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupChache.Add(new GroupData(element.Text){
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }

            return new List<GroupData>(groupChache);
        }
        public int GetGroupCount()
        {
           return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
