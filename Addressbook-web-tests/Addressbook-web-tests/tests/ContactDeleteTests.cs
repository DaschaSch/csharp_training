using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDeleteTests : ContactTestBase
    {
        
        [Test]
        public void ContactDeleteTest()
        {
            ContactData createContact = new ContactData("Danis");
            createContact.Address1 = "dfghjk";
            createContact.Address2 = "gs";
            createContact.Company = "adf";
            createContact.Email1 = "aaf@fs";
            createContact.Email2 = "gsdsg@fdsgf";
            createContact.Email3 = "sgfs@bfd";
            createContact.Fax = "123456";
            createContact.Homepage = "fghj.com";
            createContact.HomeTel1 = "7344";
            createContact.HomeTel2 = "34567";
            createContact.Lastname = "Schmidts";
            createContact.Middlename = "van";
            createContact.MobileTel = "547474676";
            createContact.Nickname = "dan";
            createContact.Notes = "lalala";
            createContact.Title = "Doc";
            createContact.WorkTel = "567483";

            app.Contacts.CreateContactIfNotPresent(createContact);

            List<ContactData> oldContact = ContactData.GetAll();
            ContactData toRemove = oldContact[0];

            app.Contacts.Remove(toRemove);

            List<ContactData> newContact = ContactData.GetAll();

            oldContact.RemoveAt(0);

            Assert.AreEqual(oldContact, newContact);

            foreach (ContactData contact in newContact)
            {
                Assert.AreNotEqual(contact.Id, toRemove.Id);
            }
        }
     }
}
