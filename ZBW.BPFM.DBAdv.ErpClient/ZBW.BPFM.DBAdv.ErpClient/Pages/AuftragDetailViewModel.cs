using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using ZBW.BPFM.DBAdv.DBAccess;
using ZBW.BPFM.DBAdv.ErpClient.Annotations;
namespace ZBW.BPFM.DBAdv.ErpClient.Pages
{
    public class AuftragDetailViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public bestellung Auftrag { get; set; }
        public ObservableCollection<kunde> Kunden { get; set; }

        public bool EnableKeyFields
        {
            get { return _enableKeyFields; }
            set
            {
                if (value == _enableKeyFields) return;
                _enableKeyFields = value;
                OnPropertyChanged();
            }
        }

        public kunde SelectedKunde
        {
            get { return Auftrag?.kunde; }
            set
            {

                if (Auftrag == null)
                    return;

                Auftrag.kunde = value != null ? Kunden.FirstOrDefault(k => k.Id == value.Id) : null;
                OnPropertyChanged();
            }
        }

        public bool CanSave => string.IsNullOrWhiteSpace(_error);

        public bool CanAddPositionen => CanSave && Auftrag != null && Auftrag.Id != 0;

        readonly AuftragRepository _repository;
        private bool _enableKeyFields;
        private string _error = "";

        public static AuftragDetailViewModel FromExisting(bestellung b)
        {
            return new AuftragDetailViewModel { Auftrag = b, EnableKeyFields = false, SelectedKunde = b.kunde };
        }

        public AuftragDetailViewModel()
        {
            _repository = new AuftragRepository();
            Auftrag = new bestellung
            {
                Bestelldatum = DateTime.Now
            };

            EnableKeyFields = true;

            var repo = new KundeRepository();
            Kunden = new ObservableCollection<kunde>(repo.GetAll().ToList());
        }

        public void UpdateAuftrag()
        {
            if (!string.IsNullOrWhiteSpace(this.Error))
                return;

            if (Auftrag.Id == 0)
                _repository.Create(Auftrag);
            else 
                _repository.Update(Auftrag);
        }

        public void RemoveAuftrag()
        {
            _repository.Remove(Auftrag.Id);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string this[string columnName]
        {
            get
            {
                var result = "";
                if (columnName == nameof(SelectedKunde))
                {
                    if (this.SelectedKunde == null)
                    {
                        result = "Bitte wählen Sie einen Kunden aus";
                    }
                }

                _error = result;
                OnPropertyChanged(nameof(CanSave));

                return result;
            }
        }

        public string Error => _error;
    }
}
