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
using ZBW.BPFM.DBAdv.ErpClient.Commands;

namespace ZBW.BPFM.DBAdv.ErpClient.Pages
{
    public class AuftragDetailViewModel : INotifyPropertyChanged
    {
        public bestellung Auftrag { get; set; }
        public SaveBestellungCommand SaveBestellungCommand { get; set; }

        public AuftragDetailViewModel(int bestellId)
        {
            var repository = new AuftragRepository();
            Auftrag = repository.GetSingle(bestellId);
            SaveBestellungCommand = new SaveBestellungCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
