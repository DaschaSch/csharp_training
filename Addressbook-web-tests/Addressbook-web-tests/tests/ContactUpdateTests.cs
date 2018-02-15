using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactUpdateTests : AuthTestBase
    {
      
        [Test]
        public void ContactUpdateTest()
        {
            #region ContactUPD Data
            ContactData contact = new ContactData("Denis");
            contact.Address1 = "dfghjk1";
            contact.Address2 = "gs1";
            contact.Company = "adf1";
            contact.Email1 = "aaf@fs1";
            contact.Email2 = "gsdsg@fdsgf1";
            contact.Email3 = "sgfs@bfd1";
            contact.Fax = "1234561";
            contact.Homepage = "fghj.com1";
            contact.HomeTel1 = "73441";
            contact.HomeTel2 = "345671";
            contact.Lastname = "Schmidt1";
            contact.Middlename = "van1";
            contact.MobileTel = "5474746761";
            contact.Nickname = "dan1";
            contact.Notes = "lalala1";
            contact.Title = "Doc1";
            contact.WorkTel = "5674831";
            #endregion
            #region Contact Create Data
            ContactData contactCreate = new ContactData("Max");
            contactCreate.Address1 = "dfghjk1";
            contactCreate.Address2 = "gs1";
            contactCreate.Company = "adf1";
            contactCreate.Email1 = "aaf@fs1";
            contactCreate.Email2 = "gsdsg@fdsgf1";
            contactCreate.Email3 = "sgfs@bfd1";
            contactCreate.Fax = "1234561";
            contactCreate.Homepage = "fghj.com1";
            contactCreate.HomeTel1 = "73441";
            contactCreate.HomeTel2 = "345671";
            contactCreate.Lastname = "Ernst";
            contactCreate.Middlename = "van1";
            contactCreate.MobileTel = "5474746761";
            contactCreate.Nickname = "dan1";
            contactCreate.Notes = "lalala1";
            contactCreate.Title = "Doc1";
            contactCreate.WorkTel = "5674831";
            #endregion

            app.Contacts.CreateContactIfNotPresent(contactCreate);

            List<ContactData> oldContact = app.Contacts.GetContactsList();

            app.Contacts.Modify(1, contact);

            List<ContactData> newContact = app.Contacts.GetContactsList();
            oldContact[0].Firstname = contact.Firstname;
            oldContact[0].Lastname = contact.Lastname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

        }
     }
}
