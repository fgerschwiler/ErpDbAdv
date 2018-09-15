using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZBW.BPFM.DBAdv.DBAccess;

namespace ZBW.BPFM.DBAdv.ErpClient.Dialogs
{
    /// <summary>
    /// Interaction logic for NeueBestellpositionDialog.xaml
    /// </summary>
    public partial class NeueBestellpositionDialog : ModernDialog
    {
        public NeueBestellpositionDialog()
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
        }

        public NeueBestellpositionDialog(bestellung b): this()
        {
            DataContext = new BestellpositionViewModel(b);
        }
    }
}
