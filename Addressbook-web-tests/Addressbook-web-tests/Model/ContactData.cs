using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname;
        private string title;
        private string company;
        private string address1;
        private string homeTel1;
        private string mobileTel;
        private string workTel;
        private string fax;
        private string email1;
        private string email2;
        private string email3;
        private string homepage;
        private string address2;
        private string homeTel2;
        private string notes;

        public ContactData(string firstname)
        {
            this.firstname = firstname;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return 1; }
            return Firstname.CompareTo(other.Firstname) + Lastname.CompareTo(other.Lastname);
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
            return "name " + Lastname + Firstname;
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Middlename
        {
            get { return middlename; }
            set { middlename = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Company
        {
            get { return company; }
            set { company = value; }
        }
        public string Address1
        {
            get { return address1; }
            set { address1 = value; }
        }
        public string HomeTel1
        {
            get { return homeTel1; }
            set { homeTel1 = value; }
        }
        public string MobileTel
        {
            get { return mobileTel; }
            set { mobileTel = value; }
        }
        public string WorkTel
        {
            get { return workTel; }
            set { workTel = value; }
        }
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        public string Email1
        {
            get { return email1; }
            set { email1 = value; }
        }
        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }
        public string Email3
        {
            get { return email3; }
            set { email3 = value; }
        }
        public string Homepage
        {
            get { return homepage; }
            set { homepage = value; }
        }
        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }
        public string HomeTel2
        {
            get { return homeTel2; }
            set { homeTel2 = value; }
        }
        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }
    }
    }
