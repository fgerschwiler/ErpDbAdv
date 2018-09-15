using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZBW.BPFM.DBAdv.DBAccess;

namespace ZBW.BPFM.DBAdv.ErpClient.Commands
{
    public class SaveBestellungCommand: ICommand
    {
        private readonly IDataRepository<bestellung> _auftragRepository;

        public SaveBestellungCommand()
        {
            _auftragRepository = new AuftragRepository();
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var bestellung = parameter as bestellung;
            if (bestellung == null)
                return;

            _auftragRepository.Update(bestellung);
        }

        public event EventHandler CanExecuteChanged;
    }
}
