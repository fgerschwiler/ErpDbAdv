using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using ZBW.BPFM.DBAdv.ErpClient.Pages;
using ZBW.BPFM.DBAdv.ErpClient.Utilities;

namespace ZBW.BPFM.DBAdv.ErpClient.Dialogs
{
    /// <summary>
    /// Interaction logic for NeueBestellpositionDialog.xaml
    /// </summary>
    public partial class BestellpositionDialog : ModernDialog
    {
        private readonly BestellpositionViewModel _viewModel;
        public BestellpositionDialog()
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
            OkButton.Click += OkButtonOnClick;
        }

        private void OkButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            try
            {
                _viewModel.Save();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(string.Join(", ", ex.EntityValidationErrors.SelectMany(e => e.ValidationErrors.Select(err => err.ErrorMessage))));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public BestellpositionDialog(bestellung b): this()
        {
            _viewModel = BestellpositionViewModel.FromBestellung(b);
            DataContext = _viewModel;
        }

        public BestellpositionDialog(bestellposition p) : this()
        {
            var repo = new BestellPositionRepository();
            p = repo.GetSingle(p.Id); // reload, so we have every assoc loaded now

            _viewModel = BestellpositionViewModel.FromExisting(p);
            DataContext = _viewModel;
     
        }
    }
}
