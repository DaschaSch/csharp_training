using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager)
            : base(manager)
        { }

        public ContactHelper Create(ContactData contact)
        {
            AddNewContactPage();
            CreateContact(contact);
            manager.Buttons.ClickSubmitButton();
            manager.Navigator.GoToHomePage();
            return this;
        }

        internal ContactHelper Remove()
        {
            manager.Navigator.GoToHomePage();
            Delete();
            return this;
        }


        internal ContactHelper Modify(int v, ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            EditContact(v);
            CreateContact(contact);
            manager.Contacts.ClickUpdateButton();
            manager.Auth.Logout();
            return this;
        }
        public ContactHelper CreateContactIfNotPresent(ContactData contact)
        {
            if (IsContactPresent() == false)
            {
                AddNewContactPage();
                CreateContact(contact);
                manager.Buttons.ClickSubmitButton();
                manager.Navigator.GoToHomePage();
            }
            return this;

        }

        public ContactHelper CreateContact(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address1);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contact.HomeTel1);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.MobileTel);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contact.WorkTel);
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(contact.Fax);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email1);
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(contact.Email3);
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage);
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(contact.Address2);
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(contact.HomeTel2);
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(contact.Notes);
            return this;
        }

        public ContactHelper AddNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])["+index+"]")).Click();
            return this;
        }
        public ContactHelper ClickUpdateButton()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private void Delete()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            driver.FindElement(By.XPath(".//*[@id='content']/form[2]/div[2]/input")).Click();
            driver.SwitchTo().Alert().Accept();
        }

        public bool IsContactPresent()
        {
            if (driver.FindElement(By.Id("search_count")).Text != "0")
            {
                return true;
            }
            return false;
        }
        public List<ContactData> GetContactsList()
        {
            List<ContactData> contacts = new List<ContactData>();

            manager.Navigator.GoToHomePage();

            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
            foreach (IWebElement element in elements)
            {
                string FirstName = element.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[3]")).Text;
                string LastName = element.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[2]")).Text;
 
                contacts.Add(new ContactData(FirstName, LastName));
            }

            return contacts;
        }

    }
}
