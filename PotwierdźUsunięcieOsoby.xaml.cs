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
using System.Windows.Shapes;

namespace P_NET_24_INIS4_PR1_1_Z2
{
    /// <summary>
    /// Logika interakcji dla klasy PotwierdźUsunięcieOsoby.xaml
    /// </summary>
    public partial class PotwierdźUsunięcieOsoby : Window
    {
        ICollection<Osoba> Osoby;
        Osoba UsuwanaOsoba;
        public PotwierdźUsunięcieOsoby(
            Osoba usuwanaOsoba,
            ICollection<Osoba> osoby
            )
        {
            DataContext = UsuwanaOsoba = usuwanaOsoba;
            Osoby = osoby;
            InitializeComponent();
        }

        private void Anuluj(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Potwierdź(object sender, RoutedEventArgs e)
        {
            Osoby.Remove(UsuwanaOsoba);
            Close();
        }
    }
}
