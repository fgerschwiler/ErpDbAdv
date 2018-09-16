using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZBW.BPFM.DBAdv.DBAccess;

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

            Buttons = new [] { OkButton, CancelButton, NoButton };
            OkButton.Click += OkButtonOnClick;
        }

        public BestellpositionDialog(bestellung b) : this()
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

        private void OnRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Remove();
            DialogResult = true;
            Close();
        }
    }
}
