﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gra_konsolowa_kopalnia
{
    internal class Komunikaty
    {
        private Gracz gracz;
        private Wybory wybory;
        private Grafiki grafiki;
        
        public Komunikaty(Gracz gracz)
        {
            this.gracz = gracz;
            grafiki = new Grafiki();
            wybory = new Wybory();
        }

        public void PrzypisanieNicku(string nick)
        {
            gracz.NickGracza = nick;
        }

        public void PodawanieNicku()
        {
            Console.WriteLine("\n\n\n\n\n\n\n");
            Console.Write("\t\t\t\t\t\t\t\t\t\t ╔════════════════════════╗ \n\t\t\t\t\t\t\t\t\t\t ║ \t\t\t  ║ \n\t\t\t\t\t\t\t\t\t\t");
            Console.Write(" ║      Podaj nick:       ║ \n\t\t\t\t\t\t\t\t\t\t ║ \t\t\t  ║ \n\t\t\t\t\t\t\t\t\t\t" +
                                                " ╚════════════════════════╝ ");
            Console.WriteLine();
        }

        public string Nick()
        {
            string NickGracza;
            Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t->  ");
            NickGracza = Console.ReadLine();
            Console.WriteLine("\n");
            while (NickGracza.Length < 4 || NickGracza.Length > 10)
            {
                Console.Write("\t\t\t\t\t\t\t\tNick musi miec dlugosc od 4 do 10 liter. Podaj nick: ");
                NickGracza = Console.ReadLine();
            }
            Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\tNick zaakceptopwany.");
            Thread.Sleep(2000);
            Console.Clear();
            return NickGracza;
        }

        void CentrowanyTekst(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            // Maksymalna długość tekstu w jednej linii
            int maxLength = 50;

            if (text.Length > maxLength)
            {
                int splitIndex = FindSplitIndex(text, maxLength);

                string part1 = text.Substring(0, splitIndex).Trim();
                string part2 = text.Substring(splitIndex).Trim();

                CentrowanyTekst(x, y, part1);
                CentrowanyTekst(x, y + 1, part2);
            }
            else
            {
                int marg = (53 - text.Length) / 2;
                string margines = new string(' ', marg);
                string nowy_tekst = margines + text + margines;
                if (nowy_tekst.Length < 53)
                {
                    nowy_tekst += " ";
                }
                PisanyTekst(nowy_tekst);
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        int FindSplitIndex(string text, int maxLength)
        {
            int newlineIndex = text.LastIndexOf('\n', maxLength);
            if (newlineIndex != -1)
            {
                return newlineIndex + 1; // Uwaga: +1 aby nie zgubić następnej linii
            }

            int spaceIndex = text.LastIndexOf(' ', maxLength);
            if (spaceIndex != -1)
            {
                return spaceIndex;
            }

            return maxLength;
        }


        void PisanyTekst(string text)
        {
            foreach (var litera in text)
            {
                Console.Write(litera);
                if (litera==' ' || litera=='\n')
                {
                    Thread.Sleep(4);
                }
                else
                {
                    Thread.Sleep(24);
                }
                
            }
            Console.WriteLine();
        }

        //public void WiadomoscPowitalna(string nick, int n, int k)
        //{
        //    List<string> wiadomoscPowitalna = new List<string>
        //    {
        //        " ",
        //        "Witaj " + nick + "!",
        //        "Trafiłeś do opuszczonej kopalni Stonemine.",
        //        "Aby przeżyć, musisz dotrzeć do wyjścia,",
        //        "wykonując po drodze rozmaite zadania.",
        //        "Musisz się śpieszyć. ",
        //        " "
        //    };

        //    for (int i = 0; i < wiadomoscPowitalna.Count; i++)
        //    {
        //        CentrowanyTekst(n, k + i, wiadomoscPowitalna[i]);
        //    }

        //}

        public void WiadomoscPowitalna(string nick, string motyw)
        {
            int n = 70;
            int k = 21;
            PisanyTekst(motyw+ "\t\t\t\t\t\tWitaj " + nick + "!");
            List<string> tab = new List<string>
            {
                "Trafiłeś do opuszczonej kopalni Stonemine. Aby przeżyć, musisz dotrzeć do wyjścia, wykonując po drodze rozmaite zadania.",
                //"Musisz się śpieszyć. Szanse na przeżycie pod ziemią maleją z każdą chwilą.",
                //"W kopalni możesz spotkać 2 rodzaje stworzeń: gobliny i potwory.", 
                //"Gobliny chętnie udzielą Ci pomocy, ponieważ chcą, żebyś jak najszybciej wydostał się z kopalni. Nie nadużywaj jednak ich gościnności - pamiętaj, nie jesteś tu mile widziany.",
                //"Uważaj na potwory. Są wygłodniałe i gustują w ludzkim mięsie. W większości sytuacji możesz przemknąć koło nich niezauważony, jeśli jednak zdecydujesz się stanąć z nimi do walki i zwycieżysz, zaskarbisz sobie wdzieczność goblinów i zdobędziesz dodatkowe punkty.",
                //"Nie zgub się w labiryncie korytarzy i staraj się wykonywać zadania jak najszybciej, by zdobyć więcej punktów.",
                "Powodzenia!"
            };


            int licznik = 0;
            grafiki.GornyPasek(gracz.NickGracza, gracz.Punkty);
            Console.ForegroundColor = ConsoleColor.White;
            grafiki.Korytarz();
            CentrowanyTekst(n, k, tab[licznik]);


            while (licznik < tab.Count)
            {
                char decyzja = wybory.WyborDalejWstecz(0, 45, motyw);
                switch (decyzja)
                {
                    case 'd':
                        licznik++;
                        if (licznik == tab.Count) return;
                        Console.Write(motyw);
                        Console.Clear();
                        grafiki.GornyPasek(gracz.NickGracza, gracz.Punkty);
                        Console.ForegroundColor = ConsoleColor.White;
                        grafiki.Korytarz();
                        CentrowanyTekst(n, k, tab[licznik]);;
                        break;

                    case 'w':
                        if (licznik > 0) licznik--;
                        Console.Write(motyw);
                        Console.Clear();
                        grafiki.GornyPasek(gracz.NickGracza, gracz.Punkty);
                        Console.ForegroundColor = ConsoleColor.White;
                        grafiki.Korytarz();
                        CentrowanyTekst(n, k, tab[licznik]);
                        break;
                }
            }
        }


        public void InstrukcjaBiegu(int n, int k)
        {
            List<string> instrukcjaBiegu = new List<string>
            {
                " ",
                "Potwór zaczął Cię gonić!",
                "Musisz uciekać ciasnymi korytarzami.",
                "Uważaj, żeby nie wbiec w ścianę",
                "Używaj strzałek ← ↑ → żeby zmieniać kierunek.",
                " "
            };

            for (int i = 0; i < instrukcjaBiegu.Count; i++)
            {
                CentrowanyTekst(n, k + i, instrukcjaBiegu[i]);
            }

        }

    }
}
