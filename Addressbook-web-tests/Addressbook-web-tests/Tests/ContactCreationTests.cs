using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Dan");
            contact.Address1 = "dfghjk";
            contact.Address2 = "gs";
            contact.Company = "adf";
            contact.Email1 = "aaf@fs";
            contact.Email2 = "gsdsg@fdsgf";
            contact.Email3 = "sgfs@bfd";
            contact.Fax = "123456";
            contact.Homepage = "fghj.com";
            contact.HomeTel1 = "7344";
            contact.HomeTel2 = "34567";
            contact.Lastname = "Schmidt";
            contact.Middlename = "van";
            contact.MobileTel = "547474676";
            contact.Nickname = "dan";
            contact.Notes = "lalala";
            contact.Title = "Doc";
            contact.WorkTel = "567483";

            app.Contacts.Create(contact);
        }
     }
}
