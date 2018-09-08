using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZBW.BPFM.DBAdv.DBAccess;
using ZBW.BPFM.DBAdv.ErpClient.Annotations;

namespace ZBW.BPFM.DBAdv.ErpClient.Pages
{
    public class AuftragDetailViewModel : INotifyPropertyChanged
    {
        private AuftragRepository _repository = null;
        
        public bestellung Auftrag { get; set; }

        public AuftragDetailViewModel(int bestellId)
        {
            _repository = new AuftragRepository();
            Auftrag = _repository.GetAuftrag(bestellId);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
