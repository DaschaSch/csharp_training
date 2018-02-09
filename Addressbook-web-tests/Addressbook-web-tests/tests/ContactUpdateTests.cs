using System;
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

            app.Contacts.Modify(contact);
        }
     }
}
