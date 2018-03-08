using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData(string gname)
        {
            GroupName = gname;
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
            GroupName = gname;
            GroupHeader = gheader;
            GroupFooter = gfooter;
        }

        public string GroupName { get; set; }
        public string GroupHeader { get; set; }
        public string GroupFooter { get; set; }
        public string Id { get; set; }
    }
}
