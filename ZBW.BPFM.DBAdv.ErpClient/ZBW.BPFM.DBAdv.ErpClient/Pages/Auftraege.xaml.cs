using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ZBW.BPFM.DBAdv.DBAccess;

namespace ZBW.BPFM.DBAdv.ErpClient.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class AuftraegeList : UserControl
    {
        public AuftraegeList()
        {
            InitializeComponent();
        }

        private void Auftrag_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement) e.OriginalSource).DataContext as bestellung;
            if (item != null)
            {
                NavigationCommands.GoToPage.Execute($"/Pages/{nameof(AuftragDetail)}.xaml#id={item.Id}", this);
            }
        }
    }
}
