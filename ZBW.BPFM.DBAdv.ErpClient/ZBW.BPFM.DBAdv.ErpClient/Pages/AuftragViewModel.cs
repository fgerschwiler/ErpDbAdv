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
        public ObservableCollection<bestellung> FilteredAuftraege { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public string SearchFilter
        {
            get { return _searchFilter; }
            set
            {
                _searchFilter = value;

                var filtered = _repository.GetAll(bestellung => bestellung.MatchesFilter(_searchFilter));

                FilteredAuftraege = new ObservableCollection<bestellung>(filtered);
                OnPropertyChanged(nameof(FilteredAuftraege));
            }
        }

        private readonly AuftragRepository _repository = null;
        private string _searchFilter;

        public AuftragViewModel()
        {
            _repository = new AuftragRepository();
            FilteredAuftraege = new ObservableCollection<bestellung>(_repository.GetAll());
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
