using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBW.BPFM.DBAdv.DBAccess;

namespace ZBW.BPFM.DBAdv.ErpClient.Pages
{
    public class AuftragViewModel
    {
        private AuftragRepository _repository = null;
        private BindingList<Bestellung> Bestellungen { get; set; }
        public AuftragViewModel()
        {
            _repository = new AuftragRepository();
            Bestellungen = new BindingList<Bestellung>(_repository.GetAuftraegeAsQueryable().ToList());
        }
    }
}
