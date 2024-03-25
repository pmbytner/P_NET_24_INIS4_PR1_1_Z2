using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P_NET_24_INIS4_PR1_1_Z2
{
    public class Osoba : INotifyPropertyChanged
    {
        private string imię = "Nemo";
        private string nazwisko = "Nowak";
        private DateTime dataUrodzenia = DateTime.Now;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotyfikujZmianęWłaściwości(
            [CallerMemberName] string nazwaWłaściwości = ""
            )
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nazwaWłaściwości)
                );
            if (PowiązaneWłaściwości.ContainsKey(nazwaWłaściwości))
                foreach (
                    string powiązanaWłaściwość
                    in PowiązaneWłaściwości[nazwaWłaściwości]
                    )
                    NotyfikujZmianęWłaściwości(powiązanaWłaściwość);
        }
        private static readonly Dictionary<string, IEnumerable<string>>
            PowiązaneWłaściwości = new()
            {
                ["Imię"] = new string[] { "ImięNazwisko" },
                ["Nazwisko"] = new string[] { "ImięNazwisko" },
                ["DataUrodzenia"] = new string[] { "Wiek" },
                ["ImięNazwisko"] = new string[] { "Format" },
                ["Wiek"] = new string[] { "Format" }
            };

        public string Imię {
            get => imię;
            set
            {
                imię = value;
                NotyfikujZmianęWłaściwości();
            }
        }
        public string Nazwisko {
            get => nazwisko;
            set
            {
                nazwisko = value;
                NotyfikujZmianęWłaściwości();
            }
        }
        public DateTime DataUrodzenia {
            get => dataUrodzenia;
            set
            {
                dataUrodzenia = value;
                NotyfikujZmianęWłaściwości();
            }
        }
        public string ImięNazwisko => $"{Imię} {Nazwisko}";
        public string Wiek
            => $"{Math.Floor((DateTime.Now - DataUrodzenia).Days / 365.25)}";
        public string Format => $"{ImięNazwisko}, {Wiek} lat.";

        public override string ToString()
        {
            return ImięNazwisko;
        }
    }
}
