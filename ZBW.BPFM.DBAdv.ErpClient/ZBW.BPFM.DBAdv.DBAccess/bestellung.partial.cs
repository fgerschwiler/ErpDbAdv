using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBW.BPFM.DBAdv.DBAccess
{
    public partial class bestellung
    {
        public string TotalPreis => this.bestellposition.Sum(p => p.Total).ToString("C", CultureInfo.CreateSpecificCulture("de-ch"));

        public bool MatchesFilter(string filter)
        {
            filter = filter.ToLowerInvariant();
            return Id.ToString().Contains(filter) || kunde.DisplayName.ToLower().Contains(filter);
        }
        
    }
}
