using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ZBW.BPFM.DBAdv.DBAccess;
using ZBW.BPFM.DBAdv.ErpClient.Annotations;

namespace ZBW.BPFM.DBAdv.ErpClient.Dialogs
{
    public class BestellpositionViewModel : INotifyPropertyChanged
    {
        private readonly IDataRepository<bestellposition> _bpositionenRepo = new BestellPositionRepository();
        private readonly IDataRepository<artikel> _artikelRepo = new DataRepository<artikel>();
        private readonly IDataRepository<lagerposition> _lagerpRepo = new LagerpositionRepository();
        private bool _enableKeyFields;

        public ObservableCollection<artikel> ArtikelSource { get; set; }
        public ObservableCollection<lagerposition> LagerPositionen { get; set; }

        public bool EnableKeyFields  
        {
            get => _enableKeyFields;
            set
            {
                if (value == _enableKeyFields) return;
                _enableKeyFields = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedArtikel));
            }
        }

        public decimal Menge
        {
            get => BestellPosition?.Menge ?? 0;
            set
            {
                if (BestellPosition == null)
                    return;

                if (Equals(value, BestellPosition.Menge))
                    return;

                BestellPosition.Menge = value;
                OnPropertyChanged(nameof(BestellPosition));
            }
        }

        public int? Rabatt
        {
            get => BestellPosition?.kundenpreis?.Rabatt;
            set
            {
                if (BestellPosition == null)
                    return;

                if (Equals(value, BestellPosition.kundenpreis.Rabatt))
                    return;

                BestellPosition.kundenpreis.Rabatt = value;
                OnPropertyChanged(nameof(BestellPosition));
            }
        }

        public DateTime? GueltigBis
        {
            get => BestellPosition?.kundenpreis?.GueltigBis;
            set
            {
                if (BestellPosition == null)
                    return;

                if (Equals(value, BestellPosition.kundenpreis.GueltigBis))
                    return;

                BestellPosition.kundenpreis.GueltigBis = value;
                OnPropertyChanged(nameof(BestellPosition));
            }
        }

        public artikel SelectedArtikel
        {
            get => BestellPosition?.artikel;
            set
            {
                if (BestellPosition == null)
                    return;

                BestellPosition.artikel = value != null ? ArtikelSource.FirstOrDefault(a => a.Id == value.Id) : null;

                OnPropertyChanged();
                OnPropertyChanged(nameof(BestellPosition));
                
                OnPropertyChanged(nameof(SelectedLagerPosition));

                Task.Factory.StartNew(() =>
                {
                    LagerPositionen = new ObservableCollection<lagerposition>(_lagerpRepo.GetAll(l => l.artikel.Id == value?.Id));
                    SelectedLagerPosition = BestellPosition.lagerposition;
                    OnPropertyChanged(nameof(LagerPositionen));
                });
            }
        }

        public lagerposition SelectedLagerPosition
        {
            get => BestellPosition?.lagerposition;
            set
            {
                if (BestellPosition == null)
                    return;

                BestellPosition.lagerposition = value != null ? LagerPositionen.FirstOrDefault(l => l.Id == value.Id) : null;

                OnPropertyChanged();
                OnPropertyChanged(nameof(BestellPosition));
            }
        }

        public bestellposition BestellPosition { get; set; }

        public BestellpositionViewModel()
        {
            ArtikelSource = new ObservableCollection<artikel>(_artikelRepo.GetAll());
            LagerPositionen = new ObservableCollection<lagerposition>(_lagerpRepo.GetAll());
        }

        public static BestellpositionViewModel FromBestellung(bestellung bestellung)
        {
            return new BestellpositionViewModel
            {
                BestellPosition = new bestellposition
                {
                    kundenpreis = new kundenpreis(),
                    bestellung =  bestellung,
                    Menge = 1
                },
                EnableKeyFields = true
            };
        }

        public static BestellpositionViewModel FromExisting(bestellposition bestellposition)
        {
            bestellposition.kundenpreis = bestellposition.kundenpreis ?? new kundenpreis();
            return new BestellpositionViewModel {
                BestellPosition = bestellposition,
                SelectedArtikel = bestellposition.artikel,
                SelectedLagerPosition = bestellposition.lagerposition,
                EnableKeyFields = false
            };
        }

        public void Save()
        {
            var p = BestellPosition;

            if (p.Id == 0)
                _bpositionenRepo.Create(p);
            else
                _bpositionenRepo.Update(p);   
        }

        public void Remove()
        {
            _bpositionenRepo.Remove(BestellPosition.Id);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
