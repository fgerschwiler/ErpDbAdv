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
    public class AuftragViewModel : INotifyPropertyChanged
    {
        private AuftragRepository _repository = null;
        private string _searchFilter;
        public ObservableCollection<bestellung> FilteredAuftraege { get; set; }

        public string SearchFilter
        {
            get { return _searchFilter; }
            set
            {
                _searchFilter = value;
                this.FilteredAuftraege = new ObservableCollection<bestellung>(_repository.GetAuftraegeAsync().Where(a => a.Id.ToString().Contains(value)));
                OnPropertyChanged(nameof(FilteredAuftraege));
            }
        }

        public AuftragViewModel()
        {
            _repository = new AuftragRepository();
            var auftraege = _repository.GetAuftraegeAsync();
            FilteredAuftraege = new ObservableCollection<bestellung>(auftraege);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
