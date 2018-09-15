using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBW.BPFM.DBAdv.DBAccess
{
    public partial class lagerposition
    {
        public override string ToString()
        {
            return $"{lager?.Bezeichnung} | An Lager: {Menge}/{MinMenge}";
        }
    }
}
