using System;
using System.Windows.Controls;
using System.Windows.Input;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

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
            var fragmentPair = e.Fragment.Split(new[] {"="}, StringSplitOptions.RemoveEmptyEntries);
            if (fragmentPair.Length != 2 || string.IsNullOrWhiteSpace(fragmentPair[1]))
            {
                return;
            }

            var id = int.Parse(fragmentPair[1]);
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
