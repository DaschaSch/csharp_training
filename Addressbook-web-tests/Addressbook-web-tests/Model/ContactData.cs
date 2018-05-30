using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allData;
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

        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string HomeTel1 { get; set; }
        public string MobileTel { get; set; }
        public string WorkTel { get; set; }
        public string Fax { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }    
        public string Address2 { get; set; }
        public string HomeTel2 { get; set; }
        public string Notes { get; set; }
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

        private string Cleanup(string phone)
        {
            if(phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
    }
}
