using System;
using System.Windows.Controls;
using System.Windows.Input;
using FirstFloor.ModernUI.Windows.Controls;
using ZBW.BPFM.DBAdv.DBAccess;
using ZBW.BPFM.DBAdv.ErpClient.Dialogs;
using ZBW.BPFM.DBAdv.ErpClient.Pages;
using ZBW.BPFM.DBAdv.ErpClient.Utilities;

namespace ZBW.BPFM.DBAdv.ErpClient.Commands
{
    public class RemoveBestellungCommand : ICommand
    {
        private readonly IDataRepository<bestellung> _auftragRepository;

        public RemoveBestellungCommand()
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

            var deletionConfirmed = PromptConfirmDialog(bestellung);
            if (!deletionConfirmed)
                return;
            
            _auftragRepository.Remove(bestellung);

            var p = $"/Pages/{nameof(Auftraege)}.xaml?{FragmentConstants.REFRESH_KEY}={FragmentConstants.DO_REFRESH}";
            NavigationCommands.GoToPage.Execute(p, null);

        }

        private bool PromptConfirmDialog(bestellung b)
        {
            var dlg = new ModernDialog
            {
                Title = "Bestellung löschen?",
                Content = $"Möchten Sie die Bestellung Nr. {b.Id} wirklich unwiederuflich löschen?",
                Width = 300,
            };

            dlg.Buttons = new [] { dlg.OkButton, dlg.CancelButton };
            return dlg.ShowDialog() ?? false;
        }

        public event EventHandler CanExecuteChanged;
    }
}