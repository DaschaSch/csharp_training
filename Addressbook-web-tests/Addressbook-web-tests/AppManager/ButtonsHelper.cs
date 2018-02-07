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
    }
}
