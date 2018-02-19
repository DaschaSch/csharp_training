using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ButtonsHelper : HelperBase
    {
        public ButtonsHelper(ApplicationManager manager)
            : base(manager)
        { }

        public void ClickNewButton()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        public void ClickDeleteButton()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
    }
}
