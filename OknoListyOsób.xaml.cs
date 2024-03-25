using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace P_NET_24_INIS4_PR1_1_Z2
{
    /// <summary>
    /// Logika interakcji dla klasy OknoListyOsób.xaml
    /// </summary>
    public partial class OknoListyOsób : Window
    {
        private ObservableCollection<Osoba> Osoby
            = new ObservableCollection<Osoba>(new Osoba[] {
                new() { Imię = "Adam", Nazwisko = "Mickiewicz" },
                new() { Imię = "Juliusz", Nazwisko = "Słowacki" },
                new() { Imię = "Wisława", Nazwisko = "Szymborska" }
            });
        public OknoListyOsób()
        {
            DataContext = Osoby;
            InitializeComponent();
        }

        private void Edytuj(object sender, RoutedEventArgs e)
        {
            Osoba wybranaOsoba = (Osoba)ListaOsób.SelectedItem;
            new OknoOsoby(wybranaOsoba).Show();
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            Osoba nowaOsoba = new();
            Osoby.Add(nowaOsoba);
            new OknoOsoby(nowaOsoba).Show();
        }

        private void Usuń(object sender, RoutedEventArgs e)
        {
            Osoba wybranaOsoba = (Osoba)ListaOsób.SelectedItem;
            new PotwierdźUsunięcieOsoby(wybranaOsoba, Osoby).Show();
        }
    }
}
