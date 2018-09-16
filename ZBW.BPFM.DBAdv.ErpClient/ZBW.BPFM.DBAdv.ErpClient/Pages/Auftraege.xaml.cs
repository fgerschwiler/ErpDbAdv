using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using ZBW.BPFM.DBAdv.DBAccess;
using ZBW.BPFM.DBAdv.ErpClient.Utilities;

namespace ZBW.BPFM.DBAdv.ErpClient.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Auftraege : UserControl, IContent
    {
        private readonly AuftragViewModel _viewModel;
        public Auftraege()
        {
            InitializeComponent();
            
            _viewModel = new AuftragViewModel();
            DataContext = _viewModel;
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            var fragment = Fragment.FromString(e.Fragment);
            if (fragment != null && IsRefreshRequested(fragment))
                _viewModel.Refresh();
        }
        private bool IsRefreshRequested(Fragment f)
        {
            return f.ContainsKey(FragmentConstants.REFRESH_KEY) && f[FragmentConstants.REFRESH_KEY] == FragmentConstants.DO_REFRESH;
        }

        private void Auftrag_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement) e.OriginalSource).DataContext as bestellung;
            if (item != null)
            {
                NavigationCommands.GoToPage.Execute($"/Pages/{nameof(AuftragDetail)}.xaml#id={item.Id}", this);
            }
        }

        private void NewBestellungButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationCommands.GoToPage.Execute($"/Pages/{nameof(AuftragDetail)}.xaml#id=0", this);
        }

        #region Empty navigation events
        public void OnNavigatedFrom(NavigationEventArgs e)
        {
        
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
         
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
          
        }
        #endregion
    }
}
