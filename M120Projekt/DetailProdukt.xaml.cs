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

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class DetailProdukt : UserControl
    {
        public DetailProdukt(ScrollViewer parent, bool isNew)
        {
            InitializeComponent();
            this.parent = parent;
            this.isNew = isNew;
            this.DataGridProdukt = new DataGridProdukt(parent);
        }

        public ScrollViewer parent;

        private DataGridProdukt DataGridProdukt;

        public bool isNew;

        public long id;

        private bool hasName = false;

        private bool hasDate = false;

        private bool isChecked = false;

        private bool hasPrice = false;

        private bool hasVersandart = false;

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            decimal preis;

            try
            {
                preis = Convert.ToDecimal(txtPreis.Text);
            }
            catch
            {
                preis = Convert.ToDecimal(0.00);
            }

            if (isNew)
            {
                if (hasName && hasDate && isChecked && hasPrice && hasVersandart)
                {
                    API.createProduct(txtName.Text, dapErscheinungsjahr.SelectedDate.Value, cbxAnLager.IsChecked.Value, preis, cbxVersandart.Text);
                    DataGridProdukt = new DataGridProdukt(parent);
                    parent.Content = DataGridProdukt;
                }
            }
            else
            {
                API.updateProdukt(id, txtName.Text, dapErscheinungsjahr.SelectedDate.Value, cbxAnLager.IsChecked.Value, preis, cbxVersandart.Text);
                DataGridProdukt = new DataGridProdukt(parent);
                parent.Content = DataGridProdukt;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Sind Sie sicher, das Sie das Produkt löschen wollen?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                API.deleteProduct(id);
                DataGridProdukt = new DataGridProdukt(parent);
                parent.Content = DataGridProdukt;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Die Änderungen gehen verloren!", "Question", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                parent.Content = DataGridProdukt;
            }
        }

        private void DatePicker_LostFocus(object sender, RoutedEventArgs e)
        {
            if (dapErscheinungsjahr.SelectedDate > DateTime.Today)
            {
                lblDatum.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                lblDatum.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void TxtPreis_LostFocus(object sender, RoutedEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"([0-9]+(?:\.(?:[1-9][1-9]|[0-9][1-9]|[1-9][0-9]))?)(?=[^0-9])");
            System.Text.RegularExpressions.Match match = regex.Match(txtPreis.Text);
            if (!match.Success)
            {
                lblPreis.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                lblPreis.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!isNew)
            {
                btnSave.IsEnabled = true;
            }

            if (txtName.Text != null)
            {
                hasName = true;
            }
            else
            {
                hasName = false;
            }
        }

        private void TxtPreis_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!isNew)
            {
                btnSave.IsEnabled = true;
            }

            if (txtPreis.Text != null)
            {
                hasPrice = true;
            }
            else
            {
                hasPrice = false;
            }
        }

        private void DapErscheinungsjahr_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isNew)
            {
                btnSave.IsEnabled = true;
            }

            if (dapErscheinungsjahr.SelectedDate != null)
            {
                hasDate = true;
            }
            else
            {
                hasDate = false;
            }
        }

        private void CbxVersandart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isNew)
            {
                btnSave.IsEnabled = true;
            }

            if (cbxVersandart.Text != null)
            {
                hasVersandart = true;
            }
            else
            {
                hasVersandart = false;
            }
        }

        private void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (!isNew)
            {
                btnSave.IsEnabled = true;
            }

            if (cbxAnLager.IsChecked != null)
            {
                isChecked = true;
            }
            else
            {
                isChecked = false;
            }
        }

        private void LblDatum_MouseEnter(object sender, MouseEventArgs e)
        {
            lblDatumInfo.Content = "Das Datum muss kleiner als " + DateTime.Today.AddDays(1).ToString("d. MMMM yyyy") + " sein";
            lblDatumInfo.Visibility = Visibility.Visible;
        }

        private void LblDatum_MouseLeave_1(object sender, MouseEventArgs e)
        {
            lblDatumInfo.Visibility = Visibility.Hidden;
        }

        private void LblPreis_MouseEnter(object sender, MouseEventArgs e)
        {
            lblPreisInfo.Visibility = Visibility.Visible;
        }

        private void LblPreis_MouseLeave(object sender, MouseEventArgs e)
        {
            lblPreisInfo.Visibility = Visibility.Hidden;
        }
    }
}
