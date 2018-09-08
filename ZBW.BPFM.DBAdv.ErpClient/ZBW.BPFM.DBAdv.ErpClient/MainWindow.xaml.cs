using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;

namespace ZBW.BPFM.DBAdv.ErpClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            AppearanceManager.Current.ThemeSource = AppearanceManager.DarkThemeSource;
        }
    }
}
