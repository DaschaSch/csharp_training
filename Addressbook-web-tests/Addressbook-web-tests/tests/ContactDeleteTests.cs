using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDeleteTests : AuthTestBase
    {
        
        [Test]
        public void ContactDeleteTest()
        {
            int v = 8;
            app.Contacts.Remove(v);
            v = v + 1; 
        }
     }
}
