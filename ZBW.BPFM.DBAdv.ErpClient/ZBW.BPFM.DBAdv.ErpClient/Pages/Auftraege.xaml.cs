using System.Windows.Controls;

namespace ZBW.BPFM.DBAdv.ErpClient.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        private readonly AuftragViewModel _viewModel = new AuftragViewModel();
        public Home()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }
    }
}
