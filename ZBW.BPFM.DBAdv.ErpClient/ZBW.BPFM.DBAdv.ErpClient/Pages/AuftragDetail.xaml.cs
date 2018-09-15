using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;
using ZBW.BPFM.DBAdv.ErpClient.Commands;
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
            if (fragment == null || fragment.Key != FragmentConstants.ID_KEY)
                return;

            var id = int.Parse(fragment.Value);
            ViewModel = new AuftragDetailViewModel(id);
            DataContext = ViewModel;
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
    }
}
