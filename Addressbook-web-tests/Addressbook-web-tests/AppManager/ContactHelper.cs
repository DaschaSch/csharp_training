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
            manager.Contacts.ClickSubmitButton();
            manager.Navigator.GoToHomePage();
            return this;
        }

        internal ContactHelper Remove()
        {
            manager.Navigator.GoToHomePage();
            Delete();
            contactChache = null;
            return this;
        }


        internal ContactHelper Modify(int v, ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            EditContact(v);
            CreateContact(contact);
            manager.Contacts.ClickUpdateButton();
            return this;
        }
        public ContactHelper CreateContactIfNotPresent(ContactData contact)
        {
            if (IsContactPresent() == false)
            {
                AddNewContactPage();
                CreateContact(contact);
                manager.Contacts.ClickSubmitButton();
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
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }
        public ContactHelper ClickUpdateButton()
        {
            driver.FindElement(By.Name("update")).Click();
            contactChache = null;
            return this;
        }
        public void ClickSubmitButton()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactChache = null;
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
        private List<ContactData> contactChache = null;
        public List<ContactData> GetContactsList()
        {
            if (contactChache == null)
            {
                contactChache = new List<ContactData>();

                manager.Navigator.GoToHomePage();

                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    string FirstName = element.FindElement(By.XPath("./td[3]")).Text;
                    string LastName = element.FindElement(By.XPath("./td[2]")).Text;

                    contactChache.Add(new ContactData(FirstName, LastName)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }         
         return new List<ContactData>(contactChache);
        }
        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            EditContact(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homeTel1 = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobileTel = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workTel = driver.FindElement(By.Name("work")).GetAttribute("value");
            string homeTel2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address1 = address,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3,
                HomeTel1 = homeTel1,
                MobileTel = mobileTel,
                WorkTel = workTel,
                HomeTel2 = homeTel2
                
            };
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;

            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            
            return new ContactData(firstName, lastName)
            {
                Address1 = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }
    }
}
