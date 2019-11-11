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
    /// Interaktionslogik für ListeProdukt.xaml
    /// </summary>
    public partial class ListeProdukt : UserControl
    {
        public ListeProdukt()
        {
            InitializeComponent();
            DataGridProdukt dataGridProdukt = new DataGridProdukt(Platzhalter);
            Platzhalter.Content = dataGridProdukt;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DetailProdukt detailProdukt = new DetailProdukt(Platzhalter, true);
            detailProdukt.HorizontalAlignment = HorizontalAlignment.Left;
            detailProdukt.Width = double.NaN;
            Platzhalter.Content = detailProdukt;
        }
    }
}
