using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{/// <summary>
/// Class represents connection to DB
/// </summary>
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        /// <summary>
        /// Constructor defines name of DB
        /// </summary>
        public AddressBookDB() : base("AddressBook") { }

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }

        public ITable<ContactData> Contacts { get { return GetTable<ContactData>(); } }

        public ITable<GroupContactRelations> GCR { get { return GetTable<GroupContactRelations>(); } }
    }
}
