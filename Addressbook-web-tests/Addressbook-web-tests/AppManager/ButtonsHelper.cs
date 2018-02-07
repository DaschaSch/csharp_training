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
        public ButtonsHelper(IWebDriver driver)
            : base(driver)
        { }
        public void ClickSubmitButton()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        public void ClickNewButton()
        {
            driver.FindElement(By.Name("new")).Click();
        }
        public void ClickEditButton()
        {
            driver.FindElement(By.Name("update")).Click();
        }
        public void ClickDeleteButton()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
    }
}
