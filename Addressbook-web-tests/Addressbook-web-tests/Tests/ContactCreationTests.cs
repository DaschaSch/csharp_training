﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(15))
                {
                    Address1 = GenerateRandomString(100),
                    Address2 = GenerateRandomString(100),
                    Company = GenerateRandomString(100),
                    Email1 = GenerateRandomString(50),
                    Email2 = GenerateRandomString(50),
                    Email3 = GenerateRandomString(50),
                    Fax = GenerateRandomString(9),
                    Homepage = GenerateRandomString(100),
                    HomeTel1 = GenerateRandomString(9),
                    HomeTel2 = GenerateRandomString(9),
                    Lastname = GenerateRandomString(15),
                    Middlename = GenerateRandomString(15),
                    MobileTel = GenerateRandomString(9),
                    Nickname = GenerateRandomString(30),
                    Notes = GenerateRandomString(1000),
                    Title = GenerateRandomString(5),
                    WorkTel = GenerateRandomString(9)
                });
            }
            return contact;
        }

        public static IEnumerable<ContactData> ContactDataFromJSONFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contact.json"));
        }

        [Test, TestCaseSource("ContactDataFromJSONFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContact = ContactData.GetAll(); 

            app.Contacts.Create(contact);

            List<ContactData> newContact = ContactData.GetAll();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, newContact);
        }
     }
}
