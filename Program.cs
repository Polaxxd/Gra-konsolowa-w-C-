using Gra_konsolowa_kopalnia;
using projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;

namespace Gra_konsolowa___kopalnia
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Console.WriteLine("\u001b[36;1m cyan");
            // \u001b[36m
            //ustawienie wielkości okna
            Console.SetWindowSize(190, 50);

            //inicjacja obiektów poszczególnych klas
            Gracz gracz = new Gracz();
            Grafiki grafiki = new Grafiki();
            Komunikaty komunikaty = new Komunikaty(gracz);
            Wybory wybory = new Wybory();
            Bieg bieg = new Bieg();
            Potwor potwor = new Potwor();
            Wyniki wyniki = new Wyniki("plikWynikow.txt");

            //wyniki.ZapiszWynik("niki", 20.43);
            //wyniki.ZapiszWynik("niki", 22);
            //wyniki.ZapiszWynik("nikita", 20.4933);
            //wyniki.ZapiszWynik("nikiliki", 11);
            //Console.WriteLine("\n\n\n");
            //Console.ReadKey();

            //bieg.uruchomBieg();

            //grafiki.RysPotworSpi(wybory.wybranyMotyw, gracz.NickGracza, gracz.Punkty);
            //Console.Clear();


            // muzyka
            SoundPlayer player = new SoundPlayer("intro.wav");

            try
            {
                player.Load();
                player.Play(); // Play sound asynchronously
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            //grafiki.Wynik(wybory.wybranyMotyw, gracz.NickGracza, gracz.Punkty);
            //Console.ReadKey();
            //Console.Clear();

            // strona startowa
            grafiki.StoneMine();
            Console.Clear();



            //wybór motywu
            wybory.WyborMotywu();
            Console.SetCursorPosition(20, 17);
            Console.WriteLine(wybory.wybranyMotyw + "Motyw wybrany!");
            Thread.Sleep(1500);
            Console.Clear();

            Console.CursorVisible = false;

            komunikaty.PodawanieNicku();
            komunikaty.PrzypisanieNicku(komunikaty.Nick());

            Console.ForegroundColor = ConsoleColor.White;
            ////belka na górze (nagłówek)
            //string linia = new string('_', 146);
            //Console.WriteLine("\t\t\t" + linia);
            //Console.WriteLine("\t\t\t" + gracz.NickGracza + '\u2665' + '❤');
            //Console.WriteLine("\t\t\t" + linia);

            //grafiki.Korytarz();


            //int n = 70;
            //int k = 21;

            //komunikaty.WiadomoscPowitalna(gracz.NickGracza, n, k);
            int samouczek = 0;
            samouczek = wybory.Samouczek(0, 25, wybory.wybranyMotyw);
            Console.Clear();
            player.Stop(); //zatrzymanie muzyki
            if (samouczek == 0)
            {
                komunikaty.WiadomoscPowitalna(gracz.NickGracza, wybory.wybranyMotyw);
                Console.Clear();
                grafiki.rysGoblin1(wybory.wybranyMotyw, gracz.NickGracza, gracz.Punkty);
            }

            double zdobytePunkty = 0;
            string akcja = "nic";

            bool graWToku = true;
            int licznikKorytarzy = 0;

            while (graWToku)
            {
                grafiki.Korytarze(wybory.wybranyMotyw, gracz.NickGracza, gracz.Punkty);
                licznikKorytarzy += 1;

                Console.Clear();

                grafiki.GornyPasek(gracz.NickGracza, gracz.Punkty);
                Console.ForegroundColor = ConsoleColor.White;
                SoundPlayer player2 = new SoundPlayer("walking.wav");
                try
                {
                    player2.Load();
                    player2.Play(); // Play sound asynchronously
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                grafiki.Korytarz();
                Thread.Sleep(4000);
                player.Stop();
                Console.Clear();

                (akcja, zdobytePunkty) = potwor.WalkaZPotworem(wybory.wybranyMotyw, gracz.NickGracza, gracz.Punkty);
                Console.Clear();
                switch (akcja)
                {
                    case "walka":
                        if (zdobytePunkty >= 0)
                        {
                            gracz.Punkty += zdobytePunkty;
                            komunikaty.WiadomoscWygranaWalka(wybory.wybranyMotyw, gracz.NickGracza, gracz.Punkty);
                        }
                        else
                        {
                            gracz.Punkty += zdobytePunkty;
                            if (gracz.Punkty < 0)
                            {
                                komunikaty.WiadomoscSmierc(wybory.wybranyMotyw, gracz.NickGracza, gracz.Punkty);
                                wyniki.ZapiszWynik(gracz.NickGracza, gracz.Punkty);
                                graWToku = false;
                            }
                            else komunikaty.WiadomoscPrzegranaWalka(wybory.wybranyMotyw, gracz.NickGracza, gracz.Punkty);
                        }
                        break;

                    case "ucieczka":
                        if (zdobytePunkty >= 300)
                        {
                            gracz.Punkty += 10;
                            komunikaty.WiadomoscSkuteczkaUcieczka(wybory.wybranyMotyw, gracz.NickGracza, gracz.Punkty);
                        }
                        else
                        {
                            gracz.Punkty += Math.Round((zdobytePunkty/30),2);
                            komunikaty.WiadomoscNieskuteczkaUcieczka(wybory.wybranyMotyw, gracz.NickGracza, gracz.Punkty);
                            wyniki.ZapiszWynik(gracz.NickGracza, gracz.Punkty);
                            graWToku = false;
                        }
                        break;
                    case "omijanie":
                        komunikaty.WiadomoscPrzemykanie(wybory.wybranyMotyw, gracz.NickGracza, gracz.Punkty);
                        break;
                    case "nic":
                        Console.WriteLine("Wystąpił błąd.");
                        break;
                }

                if (licznikKorytarzy>=6)
                {
                    komunikaty.WiadomoscWygrana(wybory.wybranyMotyw, gracz.NickGracza, gracz.Punkty);
                    graWToku = false;
                }
            }

            try
            {
                player.Load();
                player.Play(); // Play sound asynchronously
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            grafiki.Wynik(wybory.wybranyMotyw, gracz.NickGracza, gracz.Punkty);
            Console.ReadKey();








        }
    }
}
