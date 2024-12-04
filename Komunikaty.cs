using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gra_konsolowa_kopalnia
{
    internal class Komunikaty
    {
        private Gracz gracz;

        public Komunikaty(Gracz gracz)
        {
            this.gracz = gracz;
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
            Console.WriteLine("\n\n\n");
            Console.WriteLine("Nick zaakceptopwany.");
            Thread.Sleep(2000);
            Console.Clear();
            return NickGracza;
        }

        void CentrowanyTekst(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            if (text.Length > 50)
            {
                Console.WriteLine("za długi tekst");
                // jak jest za długi tp podzielić na 2 i wywołać centered tekst (pierwsza część) ceneteredtekst(druga czesc) <- i trzeba jakoś skipnąć kolejną linię w pętli
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
                Console.WriteLine(nowy_tekst);
            }

        }

        void WyswietlanieWiadomosci()
        {

        }

        public void WiadomoscPowitalna(string nick, int n, int k)
        {
            List<string> wiadomoscPowitalna = new List<string>
            {
                " ",
                "Witaj " + nick + "!",
                "Trafiłeś do opuszczonej kopalni Stonemine.",
                "Aby przeżyć, musisz dotrzeć do wyjścia,",
                "wykonując po drodze rozmaite zadania.",
                "Musisz się śpieszyć. ",
                " "
            };

            for (int i = 0; i < wiadomoscPowitalna.Count; i++)
            {
                CentrowanyTekst(n, k + i, wiadomoscPowitalna[i]);
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
