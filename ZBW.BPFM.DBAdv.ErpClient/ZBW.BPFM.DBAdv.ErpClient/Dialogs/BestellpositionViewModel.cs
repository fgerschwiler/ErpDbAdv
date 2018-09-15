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

namespace ZBW.BPFM.DBAdv.ErpClient.Dialogs
{
    public class BestellpositionViewModel : INotifyPropertyChanged
    {
        private IDataRepository<bestellposition> _bpositionenRepo;
        private readonly IDataRepository<artikel> _artikelRepo;
        private readonly IDataRepository<lagerposition> _lagerpRepo;
        private artikel _selectedArtikel;
        private lagerposition _selectedLagerPosition;
        private decimal _menge = 1;

        public ObservableCollection<artikel> ArtikelSource { get; set; }
        public ObservableCollection<lagerposition> LagerPositionen { get; set; }

        public decimal Menge
        {
            get { return _menge; }
            set
            {
                if (value == _menge) return;
                _menge = value;
                OnPropertyChanged();
            }
        }

        public artikel SelectedArtikel
        {
            get { return _selectedArtikel; }
            set
            {
                if (Equals(value, _selectedArtikel))
                    return;

                _selectedArtikel = value;
                OnPropertyChanged();

                LagerPositionen = new ObservableCollection<lagerposition>(_lagerpRepo.GetAll(l => l.artikel.Id == _selectedArtikel.Id));
                OnPropertyChanged(nameof(LagerPositionen));
            }
        }

        public lagerposition SelectedLagerPosition
        {
            get { return _selectedLagerPosition; }
            set
            {
                if (Equals(value, _selectedLagerPosition))
                    return;

                _selectedLagerPosition = value;
                OnPropertyChanged();
            }
        }

        public BestellpositionViewModel()
        {
            
        }

        public BestellpositionViewModel(bestellung b)
        {
            _bpositionenRepo = new DataRepository<bestellposition>();
            _artikelRepo = new DataRepository<artikel>();
            _lagerpRepo = new LagerpositionRepository();

            ArtikelSource = new ObservableCollection<artikel>(_artikelRepo.GetAll());
            LagerPositionen = new ObservableCollection<lagerposition>(_lagerpRepo.GetAll()); 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
