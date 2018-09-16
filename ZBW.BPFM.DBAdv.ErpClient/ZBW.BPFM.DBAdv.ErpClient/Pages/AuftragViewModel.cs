using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
            get => _searchFilter;
            set
            {
                _searchFilter = value;

                var filtered = string.IsNullOrWhiteSpace(_searchFilter)
                    ? _repository.GetAll()
                    : _repository.GetAll(b => b.MatchesFilter(_searchFilter));
                    
                FilteredAuftraege = new ObservableCollection<bestellung>(filtered);
                OnPropertyChanged(nameof(FilteredAuftraege));
            }
        }

        private readonly AuftragRepository _repository;
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

        public void Refresh()
        {
            SearchFilter = _searchFilter;
        }
    }
}
