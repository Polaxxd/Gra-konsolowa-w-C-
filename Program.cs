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

            Console.SetWindowSize(190, 50);

            Bieg bieg = new Bieg();
            //bieg.uruchomBieg();
            Wybory wybory = new Wybory();
            wybory.WyborMotywu();
            Console.Clear();
            Console.WriteLine("\u001b[0m motyw: " + wybory.wybranyMotyw + "wybrany");

            Console.CursorVisible = false;
            
            Console.ReadLine();

            //Gracz gracz = new Gracz();
            //Grafiki grafiki = new Grafiki();
            //Komunikaty komunikaty = new Komunikaty(gracz);

            //komunikaty.PodawanieNicku();
            //komunikaty.PrzypisanieNicku(komunikaty.Nick());


            //Console.Clear();
            ////belka na górze (nagłówek)
            //string linia = new string('_', 146);
            //Console.WriteLine("\t\t\t" + linia);
            //Console.WriteLine("\t\t\t" + gracz.NickGracza + '\u2665' + '❤');
            //Console.WriteLine("\t\t\t" + linia);

            //grafiki.Korytarz();


            //int n = 70;
            //int k = 21;

            //komunikaty.WiadomoscPowitalna(gracz.NickGracza, n, k);


        }
    }
}
