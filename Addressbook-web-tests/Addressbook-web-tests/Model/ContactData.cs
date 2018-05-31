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
        public string Firstname { get; set; }
        [Column(Name = "middlename")]
        public string Middlename { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        [Column(Name = "nickname")]
        public string Nickname { get; set; }
        [Column(Name = "title")]
        public string Title { get; set; }
        [Column(Name = "company")]
        public string Company { get; set; }
        [Column(Name = "address")]
        public string Address1 { get; set; }
        [Column(Name = "home")]
        public string HomeTel1 { get; set; }
        [Column(Name = "mobile")]
        public string MobileTel { get; set; }
        [Column(Name = "work")]
        public string WorkTel { get; set; }
        [Column(Name = "fax")]
        public string Fax { get; set; }
        [Column(Name = "email")]
        public string Email1 { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }
        [Column(Name = "homepage")]
        public string Homepage { get; set; }
        [Column(Name = "address2")]
        public string Address2 { get; set; }
        [Column(Name = "phone2")]
        public string HomeTel2 { get; set; }
        [Column(Name = "notes")]
        public string Notes { get; set; }

        #region AllPhones and Cleanup
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

        private string Cleanup(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
        #endregion

        #region AllEmails and Cleanup
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
                    return (CleanupEmail(Email1) + CleanupEmail(Email2) + CleanupEmail(Email3)).Trim();
                }
            }
            set { allEmails = value; }
        }

        private string CleanupEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            else
            {
                return Regex.Replace(email, "[ -()]", "") + "\r\n";
            }
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
                return (from g in db.Contacts select g).ToList();
            }
        }
    }
}
