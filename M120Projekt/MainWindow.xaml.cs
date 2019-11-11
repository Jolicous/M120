using System.Windows;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ListeProdukt listeProdukt = new ListeProdukt();
            Platzhalter.Content = listeProdukt;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Bestellung bestellung = new Bestellung();
            Platzhalter.Content = bestellung;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Kontakt kontakt = new Kontakt();
            Platzhalter.Content = kontakt;
        }
    }
}
