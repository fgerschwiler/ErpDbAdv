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

        public bool HasError
        {
            get => _hasError;
            set
            {
                if (value == _hasError) return;
                _hasError = value;
                OnPropertyChanged();
            }
        }

        public bool HasSuccess
        {
            get => _hasSuccess;
            set
            {
                if (value == _hasSuccess) return;
                _hasSuccess = value;
                OnPropertyChanged();
            }
        }

        private readonly AuftragRepository _repository = null;
        private string _searchFilter;
        private bool _hasError;
        private bool _hasSuccess;

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
