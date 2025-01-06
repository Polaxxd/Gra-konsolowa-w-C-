using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Gra_konsolowa_kopalnia;
using System.Media;

namespace projekt
{
    class Potwor
    {
        private Wybory wybory;
        private Grafiki grafiki;
        private Komunikaty komunikaty;
        private Bieg bieg;

        public Potwor()
        {
            wybory = new Wybory();
            grafiki = new Grafiki();
            komunikaty = new Komunikaty();
            bieg = new Bieg();
        }

        public double Punkty { get; set; }


        public string PotworDecyzja(string motyw)       // sprawdza czy użytkownik chce walczyć z potworem
        {
            Console.WriteLine("\n\t\t\tĆiii! Przy ścianie leży śpiący potwór. Zdecyduj czy chcesz z nim walczyć.\n" +
                "\t\t\tJeśli wygrasz, zdobędziesz dodatowe punkty, ale jeśli przegrasz... Potwory nie mają litości.\n" +
                "\t\t\tZastanów się dobrze.");
            return wybory.WyborWalki(motyw);
        }

        public void Zasady()                // wyświetlanie zasad dla użytkownika
        {
            Console.WriteLine("\n\t\t\tAby zaatakować potwora, wpisuj znaki pojawiające się na ekranie i zatwierdzaj klawiszem enter.\n" +
                                "\t\t\tŚpiesz się, bestia wykorzysta każdy moment Twojego zawahania!");
            Console.WriteLine("\t\t\tNaciśnij dowolny klawisz, żeby rozpocząć.");
            Console.ReadKey();
            Console.WriteLine();
        }

        public static List<int> ListaLiczb()        // losowanie liczb
        {
            List<int> liczby = new List<int>();
            Random los = new Random();
            for (int i = 0; i < 10; i++)
                liczby.Add(los.Next(10));
            return liczby;
        }

        public static List<char> ListaLiter()       // stała lista liter
        {
            List<char> litery = new List<char>
            {
                'w', 'a', 'l', 'c', 'z', 'w', 'a', 'l', 'c', 'z'
            };
            return litery;
        }

        public static List<char> ListaLiter2()       // lista liter do ćwiczeń
        {
            List<char> litery = new List<char>
            {
                'c', 'w', 'i', 'c', 'z'
            };
            return litery;
        }

        public static List<string> Polaczone(List<int> liczby, List<char> literki)      //łączenie list z liczbami i literami
        {
            List<string> razem = liczby.Zip(literki, (liczba, literka) => (liczba.ToString() + literka.ToString())).ToList();
            return razem;
        }

        public double PotworWalka(List<string> znaki)         // walka właściwa
        {
            double punkty = 0;
            string uzytkownik;
            Random los = new Random();


            SoundPlayer player = new SoundPlayer("roar.wav");

            foreach (string elem in znaki)
            {
                double punktyDodane = (los.Next(3)*100 + los.Next(100));
                //int punktyDodaneInt = (int)punktyDodane;
                punktyDodane = punktyDodane / 100;
                int atak = 1 + los.Next(5);
                Console.WriteLine("\t\t\t" + elem + " +enter");
                // czas start
                var ms1 = (DateTime.UtcNow - DateTime.MinValue).TotalMilliseconds;
                Console.Write("\t\t\t");
                uzytkownik = Console.ReadLine();
                var ms2 = (DateTime.UtcNow - DateTime.MinValue).TotalMilliseconds;
                if (ms2 - ms1 > 3500)
                {
                    player.Load();
                    player.Play();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\tZbyt wolno! Potwór atakuje! \n\t\t\tAtak -" + atak);
                    punkty -= atak;
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else if (uzytkownik == elem)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\tAtak udany! +" + punktyDodane);
                    punkty += punktyDodane;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    player.Load();
                    player.Play();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\tBłąd! Potwór atakuje! \n\t\t\t Atak -" + atak);
                    punkty -= atak;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine("\n\n\t\t\tKoniec walki. Zdobyte punkty: " + punkty);
            Console.WriteLine("\t\t\tNaciśnij dowolny klawisz, żeby przejść dalej.");
            Console.ReadKey();
            Punkty = punkty;
            return punkty;
        }

        public void PotworCwiczenie(List<string> znaki)         // ćwiczenie przed walką
        {
            Console.WriteLine("\n\t\t\tZnaki pojawiające się na ekranie, to zawsze para: cyfra + mała litera, np. 3k.");
            string uzytkownik;

            foreach (string elem in znaki)
            {
                
                Console.WriteLine("\t\t\t" + elem + " +enter");
                // czas start
                var ms1 = (DateTime.UtcNow - DateTime.MinValue).TotalMilliseconds;
                Console.Write("\t\t\t");
                uzytkownik = Console.ReadLine();
                var ms2 = (DateTime.UtcNow - DateTime.MinValue).TotalMilliseconds;
                if (ms2 - ms1 > 4500)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\tSpróbuj szybciej, w przeciwnym wypadku zaatakuje cię potwór!\n\t\t");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else if (uzytkownik == elem)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\tBrawo! Atak udany! +");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\tBłąd! Potwór zatakuje! \n\t\t\t");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine("\n\n\t\t\tWystarczy ćwiczeń, teraz zmierz się z prawdziwym potworem.");
            Console.WriteLine("\t\t\tNaciśniej dowolny klawisz, żeby kontynuować.");
            Console.ReadKey();
            
        }

        public int PotworOmijanie()
        {
            Random los = new Random();
            int sukces = los.Next(4);

            return sukces;
        }


        public (string akcja, double wynik) WalkaZPotworem(string motyw, string nick, double punkty)
        {
            string akcja = "nic";
            Punkty = 0;

            grafiki.RysPotwor(motyw, nick, punkty);
            string decyzja = PotworDecyzja(motyw);
            Console.Clear();
            if (decyzja == "walka")
            {
                akcja = "walka";
                grafiki.RysPotworOczy(motyw, nick, punkty);
                Zasady();
                List<int> liczby = Potwor.ListaLiczb();
                List<char> literki = Potwor.ListaLiter();
                List<string> razem = Potwor.Polaczone(liczby, literki);
                PotworWalka(razem);
            }
            else if (decyzja == "pomoc") 
            {
                akcja = "walka";
                grafiki.RysGoblin2(motyw, nick, punkty);
                Console.Clear ();
                grafiki.RysGoblin(motyw, nick, punkty);
                Console.WriteLine("\t\t\tNauczę Cię walczyć z potworem.");
                Zasady();
                List<int> liczby = Potwor.ListaLiczb();
                List<char> literki = Potwor.ListaLiter2();
                List<string> razem = Potwor.Polaczone(liczby, literki);
                PotworCwiczenie(razem);

                // prawdziwa walka
                Console.Clear ();
                grafiki.RysPotworOczy(motyw, nick, punkty);
                Zasady();
                liczby = Potwor.ListaLiczb();
                literki = Potwor.ListaLiter();
                razem = Potwor.Polaczone(liczby, literki);
                PotworWalka(razem);
            }
            else
            {
                if (PotworOmijanie() != 3)
                {
                    akcja = "ucieczka";
                    grafiki.RysPotworPobudka(motyw, nick, punkty);
                    Console.Clear();

                    Console.Write(motyw);
                    grafiki.GornyPasek(nick, punkty);
                    grafiki.Korytarz();
                    komunikaty.InstrukcjaBiegu(70, 21, motyw);
                    Console.Clear();
                    int punktyZBiegu = bieg.uruchomBieg();
                    Punkty = punktyZBiegu;
                }
                else
                {
                    akcja = "omijanie";
                    grafiki.RysPotworSpi(motyw, nick, punkty);
                    Console.Clear ();
                }

            }
            return (akcja, Punkty);
        }
    }
}
