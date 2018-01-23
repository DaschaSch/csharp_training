using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class GroupData
    {
        private string gname;
        private string gheader;
        private string gfooter;

        public GroupData(string gname)
        {
            this.gname = gname;
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
