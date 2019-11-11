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
using M120Projekt.Data;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für DataGridProdukt.xaml
    /// </summary>
    public partial class DataGridProdukt : UserControl
    {
        public DataGridProdukt(ScrollViewer parent)
        {
            InitializeComponent();

            this.parent = parent;

            dagTabelle.ItemsSource = API.readProduct();

            dagTabelle.CanUserAddRows = false;
            dagTabelle.CanUserSortColumns = false;
            dagTabelle.IsReadOnly = true;
        }

        public ScrollViewer parent;

        private void DagTabelle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Produkt auswahl = (Produkt)dagTabelle.SelectedItem;

            DetailProdukt detailProdukt = new DetailProdukt(parent, false);
            detailProdukt.id = auswahl.ProduktID;
            detailProdukt.txtName.Text = auswahl.ProduktName;
            detailProdukt.dapErscheinungsjahr.SelectedDate = auswahl.Erscheinungsdatum;
            detailProdukt.txtPreis.Text = auswahl.Preis.ToString();
            detailProdukt.cbxAnLager.IsChecked = auswahl.AnLager;
            detailProdukt.cbxVersandart.Text = auswahl.Versandart;

            parent.Content = detailProdukt;
        }
    }
}
