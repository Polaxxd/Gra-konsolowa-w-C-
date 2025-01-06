using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace Gra_konsolowa_kopalnia
{
    public class Wyniki
    {
        private string sciezkaPliku;

        public Wyniki(string sciezkaPliku)
        {
            this.sciezkaPliku = sciezkaPliku;
        }

        // Dodaje wynik do pliku
        public void ZapiszWynik(string nick, double wynik)
        {
            using (StreamWriter writer = new StreamWriter(sciezkaPliku, true))
            {
                writer.WriteLine($"{nick};{wynik}");
            }
            //Console.WriteLine($"Zapisano: {nick} {wynik}");
        }

        public void WyswietlWyniki()
        {
            if (!File.Exists(sciezkaPliku))
            {
                Console.WriteLine("Brak wyników do wyświetlenia.");
                return;
            }

            List<(string Nick, double Wynik)> listaWynikow = new List<(string, double)>();

            using (StreamReader reader = new StreamReader(sciezkaPliku))
            {
                string linia;
                while ((linia = reader.ReadLine()) != null)
                {
                    var dane = linia.Split(';');
                    if (dane.Length == 2 && double.TryParse(dane[1], out double wynik))
                    {
                        listaWynikow.Add((dane[0], wynik));
                    }
                }
            }

            var posortowaneWyniki = listaWynikow.OrderByDescending(w => w.Wynik).ToList();

            Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t+-----------------+---------+");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| Nick            | Wynik   |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t+-----------------+---------+");

            foreach (var (nick, wynik) in posortowaneWyniki)
            {
                Console.WriteLine($"\t\t\t\t\t\t\t\t\t\t| {nick.PadRight(15)} | {wynik,7:F2} |");
            }

            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t+-----------------+---------+");
        }
    }
}

