using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBW.BPFM.DBAdv.DBAccess
{
    public partial class kunde
    {
        public string DisplayName =>  this.person != null ? this.person.Vorname + " " + this.person.Name : Organisation;
    }
}
