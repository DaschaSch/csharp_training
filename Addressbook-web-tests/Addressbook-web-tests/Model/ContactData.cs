using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allData;
        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname;
        private string title;
        private string company;
        private string address1;
        private string fax;
        private string homepage;
        private string address2;
        private string notes;


        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }
        public ContactData()
        { }
        public ContactData(string firstname)
        {
            Firstname = firstname;
        }
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return 1; }
            return (Firstname+Lastname).CompareTo(other.Firstname + other.Lastname);
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname + Lastname == other.Firstname + other.Lastname;
        }

        //override - rewrite element set in base class
        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }
        public override string ToString()
        {
            return "name " + Firstname + Lastname;
        }

        [Column(Name = "firstname")]
        public string Firstname
        {
            get
            {
                if (firstname != null)
                {
                    return firstname;
                }
                else
                {
                    return (Cleanup(Firstname).Trim());
                }
            }
            set { firstname = value; }
        }

        [Column(Name = "middlename")]
        public string Middlename
        {
            get
            {
                if (middlename != null)
                {
                    return middlename;
                }
                else
                {
                    return (Cleanup(Middlename).Trim());
                }
            }
            set { middlename = value; }
        }

        [Column(Name = "lastname")]
        public string Lastname
        {
            get
            {
                if (lastname != null)
                {
                    return lastname;
                }
                else
                {
                    return (Cleanup(Lastname).Trim());
                }
            }
            set { lastname = value; }
        }

        [Column(Name = "nickname")]
        public string Nickname
        {
            get
            {
                if (nickname != null)
                {
                    return nickname;
                }
                else
                {
                    return (Cleanup(Nickname).Trim());
                }
            }
            set { nickname = value; }
        }

        [Column(Name = "title")]
        public string Title
        {
            get
            {
                if (title != null)
                {
                    return title;
                }
                else
                {
                    return (Cleanup(Title).Trim());
                }
            }
            set { title = value; }
        }

        [Column(Name = "company")]
        public string Company
        {
            get
            {
                if (company != null)
                {
                    return company;
                }
                else
                {
                    return (Cleanup(Company).Trim());
                }
            }
            set { company = value; }
        }

        [Column(Name = "address")]
        public string Address1
        {
            get
            {
                if (address1 != null)
                {
                    return address1;
                }
                else
                {
                    return (Cleanup(Address1).Trim());
                }
            }
            set { address1 = value; }
        }

        [Column(Name = "home")]
        public string HomeTel1 { get; set; }
        [Column(Name = "mobile")]
        public string MobileTel { get; set; }
        [Column(Name = "work")]
        public string WorkTel { get; set; }
        [Column(Name = "fax")]
        public string Fax
        {
            get
            {
                if (fax != null)
                {
                    return fax;
                }
                else
                {
                    return (Cleanup(Fax).Trim());
                }
            }
            set { fax = value; }
        }

        [Column(Name = "email")]
        public string Email1 { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        [Column(Name = "homepage")]
        public string Homepage
        {
            get
            {
                if (homepage != null)
                {
                    return homepage;
                }
                else
                {
                    return (Cleanup(Homepage).Trim());
                }
            }
            set { homepage = value; }
        }

        [Column(Name = "address2")]
        public string Address2
        {
            get
            {
                if (address2 != null)
                {
                    return address2;
                }
                else
                {
                    return (Cleanup(Address2).Trim());
                }
            }
            set { address2 = value; }
        }

        [Column(Name = "phone2")]
        public string HomeTel2 { get; set; }

        [Column(Name = "notes")]
        public string Notes
        {
            get
            {
                if (notes != null)
                {
                    return notes;
                }
                else
                {
                    return (Cleanup(Notes).Trim());
                }
            }
            set { notes = value; }
        }

        private string Cleanup(string element)
        {
            if (element == null || element == "")
            {
                return "";
            }
            else
            {
                return Regex.Replace(element, "[ -()]", "") + "\r\n";
            }
        }

        #region AllPhones
        public string AllPhones {
            get {
                if(allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (Cleanup(HomeTel1) + Cleanup(MobileTel) + Cleanup(WorkTel)) + Cleanup(HomeTel2).Trim();
                }
             }
            set { allPhones = value; }
        }

        #endregion

        #region AllEmails
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (Cleanup(Email1) + Cleanup(Email2) + Cleanup(Email3)).Trim();
                }
            }
            set { allEmails = value; }
        }

        #endregion

        public string FeaturesData
        { 
            get
            {
                if (allData != null)
                {
                    return allData;
                }
                else
                {
                    return Firstname + " " + Middlename + " " + Lastname + "\r\n"
      + Nickname + "\r\n" + Title + "\r\n" + Company + "\r\n"
      + Address1 + "\r\n\r\n" + "H: " + HomeTel1 + "\r\n" + "M: " + MobileTel + "\r\n" + "W: "
      + WorkTel + "\r\n" + "F: " + Fax + "\r\n\r\n" + AllEmails + "\r\n"
      + "Homepage:" + "\r\n" + Homepage + "\r\n\r\n\r\n" + Address2 + "\r\n\r\n" + "P: " + HomeTel2 
      + "\r\n\r\n" + Notes;

                }
            }
            set { allData = value; }
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select g).ToList();
            }
        }
    }
}
