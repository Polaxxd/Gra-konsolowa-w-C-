using Gra_konsolowa_kopalnia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gra_konsolowa___kopalnia
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //ustawienie wielkości okna
            Console.SetWindowSize(190, 50);

            //inicjacja obiektów poszczególnych klas
            Gracz gracz = new Gracz();
            Grafiki grafiki = new Grafiki();
            Komunikaty komunikaty = new Komunikaty(gracz);
            Wybory wybory = new Wybory();
            Bieg bieg = new Bieg();
            //bieg.uruchomBieg();

            // strona startowa
            grafiki.StoneMine();
            Console.Clear();

            //wybór motywu
            wybory.WyborMotywu();
            Console.WriteLine(wybory.wybranyMotyw + "Motyw wybrany!");
            Thread.Sleep(1500);
            Console.Clear();

            Console.CursorVisible = false;
            
            komunikaty.PodawanieNicku();
            komunikaty.PrzypisanieNicku(komunikaty.Nick());


            Console.Clear();
            ////belka na górze (nagłówek)
            //string linia = new string('_', 146);
            //Console.WriteLine("\t\t\t" + linia);
            //Console.WriteLine("\t\t\t" + gracz.NickGracza + '\u2665' + '❤');
            //Console.WriteLine("\t\t\t" + linia);

            //grafiki.Korytarz();


            //int n = 70;
            //int k = 21;

            //komunikaty.WiadomoscPowitalna(gracz.NickGracza, n, k);
            komunikaty.WiadomoscPowitalna(gracz.NickGracza, wybory.wybranyMotyw);




        }
    }
}
