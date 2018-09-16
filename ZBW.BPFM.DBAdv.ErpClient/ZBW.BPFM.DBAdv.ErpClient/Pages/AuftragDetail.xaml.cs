using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;
using ZBW.BPFM.DBAdv.DBAccess;
using ZBW.BPFM.DBAdv.ErpClient.Dialogs;
using ZBW.BPFM.DBAdv.ErpClient.Utilities;

namespace ZBW.BPFM.DBAdv.ErpClient.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class AuftragDetail: UserControl, IContent
    {
        public AuftragDetailViewModel ViewModel;
        public AuftragDetail()
        {
            InitializeComponent();
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            var fragment = Fragment.FromString(e.Fragment);
            if (fragment == null)
                return;

            if (fragment.ContainsKey(FragmentConstants.ID_KEY))
            {
                var id = int.Parse(fragment[FragmentConstants.ID_KEY]);
                if (id == 0)
                {
                    ViewModel = new AuftragDetailViewModel();
                    DataContext = ViewModel;
                }
                else
                {
                    Reload(id);
                }
            }
        }

        private void Reload(int id)
        {
            var repo = new AuftragRepository();
            ViewModel = AuftragDetailViewModel.FromExisting(repo.GetSingle(id));
            DataContext = ViewModel;
        }

        private void OnRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!PromptConfirmDialog())
                return;

            ViewModel.RemoveAuftrag();

            var p = $"/Pages/{nameof(Auftraege)}.xaml?{FragmentConstants.REFRESH_KEY}={FragmentConstants.DO_REFRESH}";
            NavigationCommands.GoToPage.Execute(p, null);
        }

        private void OnAddBestellpositionButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.ViewModel.Error))
            {
                return;
            }
              
            var success = PromptNewBestellpositionDialog();
            if (success)
            {
                Reload(ViewModel.Auftrag.Id);
            }
        }

        private void OnSaveButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.UpdateAuftrag();
            Reload(ViewModel.Auftrag.Id);
        }

        private bool PromptNewBestellpositionDialog()
        {
            var dlg = new BestellpositionDialog(ViewModel.Auftrag)
            {
                Title = "Neue Bestellposition",
                Width = 500,
            };

            dlg.Buttons = new[] { dlg.OkButton, dlg.CancelButton };
            return dlg.ShowDialog() ?? false;
        }

        private bool PromptUpdateBestellpositionDialog(bestellposition p)
        {
            var dlg = new BestellpositionDialog(p)
            {
                Title = "Bestellposition ändern",
                Width = 500,
            };

            dlg.Buttons = new[] { dlg.OkButton, dlg.CancelButton };
            return dlg.ShowDialog() ?? false;
        }

        private bool PromptConfirmDialog()
        {
            var dlg = new ModernDialog
            {
                Title = "Bestellung löschen?",
                Content = $"Möchten Sie die Bestellung Nr. {ViewModel.Auftrag.Id} wirklich unwiederuflich löschen?",
                Width = 300,
            };

            dlg.Buttons = new[] { dlg.OkButton, dlg.CancelButton };
            return dlg.ShowDialog() ?? false;
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {

        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

        }

        private void OnBestellposition_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as bestellposition;
            if (item != null)
            {
                var success = PromptUpdateBestellpositionDialog(item);
                if (success)
                {
                    Reload(item.bestellung.Id);
                }

            }
        }
    }
}
