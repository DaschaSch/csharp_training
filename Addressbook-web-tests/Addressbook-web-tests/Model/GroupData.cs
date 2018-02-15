using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        private string gname;
        private string gheader;
        private string gfooter;

        public GroupData(string gname)
        {
            this.gname = gname;
        }
        public int CompareTo(GroupData other)
        {
            if(Object.ReferenceEquals(other, null))
            { return 1; }
            return GroupName.CompareTo(other.GroupName);
        }
        public bool Equals(GroupData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if(Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return GroupName == other.GroupName;
        }
        //override - rewrite element set in base class
        public override int GetHashCode()
        {
            return GroupName.GetHashCode();
        }
        public override string ToString()
        {
            return "name " + GroupName;
        }
        public GroupData(string gname, string gheader, string gfooter)
        {
            this.gname = gname;
            this.gheader = gheader;
            this.gfooter = gfooter;
        }

        public string GroupName
        {
            get { return gname; }
            set { gname = value; }
        }
        public string GroupHeader
        {
            get { return gheader; }
            set { gheader = value; }
        }
        public string GroupFooter
        {
            get { return gfooter; }
            set { gfooter = value; }
        }

    }
}
