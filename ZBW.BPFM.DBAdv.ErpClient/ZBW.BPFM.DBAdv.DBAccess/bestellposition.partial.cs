using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBW.BPFM.DBAdv.DBAccess
{
    public partial class bestellposition
    {
        public decimal Total
        {
            get
            {
                if (artikel == null)
                    return 0;

                var vp = artikel.BruttoVP;

                if (kundenpreis != null)
                {
                    if (kundenpreis.GueltigBis.HasValue && kundenpreis.GueltigBis < DateTime.Now)
                        return vp;

                    if (kundenpreis.Rabatt.HasValue && kundenpreis.Rabatt > 0)
                    {
                        var rabatt = vp * kundenpreis.Rabatt.Value / 100;
                        vp -= rabatt;
                        kundenpreis.Verkaufspreis = vp;
                    }
                    else
                    {
                        var kvp = kundenpreis.Verkaufspreis;
                        kundenpreis.Rabatt = (int)(kvp * 100 / vp);
                    }
                }

                return vp * Menge;
            }
        }
    }
}
