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
        public string TotalPreis => this.bestellposition
            .Where(p => p.kundenpreis != null || p.artikel != null)
            .Sum(p => p.kundenpreis?.Verkaufspreis ?? p.artikel.BruttoVP).ToString("C", CultureInfo.CreateSpecificCulture("de-ch"));
    }
}
