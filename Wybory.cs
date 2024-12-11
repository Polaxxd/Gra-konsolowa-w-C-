using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Gra_konsolowa_kopalnia
{
    internal class Wybory
    {

        public string wybranyMotyw { get; set; }

        // Szablon
//        Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine("←→↑↓");
//            Console.ResetColor();
//            Console.WriteLine("\nUse ↑  and ↓  to navigate and press \u001b[32mEnter/Return\u001b[0m to select:");
//            (int left, int top) = (0, 10);
//            var option = 1;
//        var decorator = "\u001b[32m → ";
//        ConsoleKeyInfo key;
//        bool isSelected = false;

//            while (!isSelected)
//            {
//                Console.SetCursorPosition(left, top);

//                Console.WriteLine($"{(option == 1 ? decorator : "   ")}Option 1\u001b[0m");
//                Console.WriteLine($"{(option == 2 ? decorator : "   ")}Option 2\u001b[0m");
//                Console.WriteLine($"{(option == 3 ? decorator : "   ")}Option 3\u001b[0m");

//                key = Console.ReadKey(false);

//                switch (key.Key)
//                {
//                    case ConsoleKey.UpArrow:
//                        option = option == 1 ? 3 : option - 1;
//                        break;

//                    case ConsoleKey.DownArrow:
//                        option = option == 3 ? 1 : option + 1;
//                        break;

//                    case ConsoleKey.Enter:
//                        isSelected = true;
//                        break;
//                }
//}

//              Console.WriteLine($"\n{decorator}You selected Option {option}");
    
            
        
        public void WyborMotywu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine("←→↑↓");
            Console.WriteLine("\nUżyj strzałek ↑ i ↓ do poruszania i naciśnij Enter żeby wybrać kolor motywu:");
            (int left, int top) = (0, 10);
            var option = 0;
            var decorator = "\u001b[32m → ";
            ConsoleKeyInfo key;
            bool isSelected = false;
            List<string> listaOpcji = new List<string>
            {
                "Zielony",
                "Żółty",
                "Niebieski",
                "Czerwony",
                "Biały"
            };

            while (!isSelected)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(left, top);

                for (int i = 0; i < listaOpcji.Count; i++)
                {
                    Console.WriteLine($"{(option == i ? "\t\t\t"+decorator : "\t\t\t   ")}" +listaOpcji[i]+"\u001b[0m");
                }

                //Console.WriteLine($"{(option == 1 ? decorator : "   ")}Zielony\u001b[0m");
                //Console.WriteLine($"{(option == 2 ? decorator : "   ")}Żółty\u001b[0m");
                //Console.WriteLine($"{(option == 3 ? decorator : "   ")}Niebieski\u001b[0m");
                //Console.WriteLine($"{(option == 4 ? decorator : "   ")}Czerwony\u001b[0m");
                //Console.WriteLine($"{(option == 5 ? decorator : "   ")}Biały\u001b[0m");

                key = Console.ReadKey(false);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 0 ? listaOpcji.Count : option - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        option = option == listaOpcji.Count ? 0 : option + 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }

            string chosenOption = "";
            switch (option)
            {
                case 0:
                    chosenOption = "\u001b[32m"; //zielony
                    break;

                case 1:
                    chosenOption = "\u001b[33m"; //żółty
                    break;

                case 2:
                    chosenOption = "\u001b[36m"; //niebieski
                    break;

                case 3:
                    chosenOption = "\u001b[31m"; //czerwony
                    break;

                case 4:
                    chosenOption = "\u001b[37m"; //biały
                    break;
            }

            wybranyMotyw = chosenOption;
        }


        public char WyborDalejWstecz(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nUżyj strzałek ↑ i ↓ do poruszania i naciśnij Enter żeby wybrać opcję:");
            //(int left, int top) = (Console.CursorLeft, Console.CursorTop + 1) ; // Pobiera aktualną pozycję kursora
            (left, top) = (0, Console.CursorTop + 1);

            var option = 0;
            var decorator = "\u001b[32m → ";
            ConsoleKeyInfo key;
            bool isSelected = false;
            List<string> listaOpcji = new List<string> { "Dalej", "Wstecz" };

            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                for (int i = 0; i < listaOpcji.Count; i++)
                {
                    Console.WriteLine($"{(option == i ? decorator : "   ")}{listaOpcji[i]}\u001b[0m");
                }

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = (option - 1 + listaOpcji.Count) % listaOpcji.Count;
                        break;

                    case ConsoleKey.DownArrow:
                        option = (option + 1) % listaOpcji.Count; 
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true; 
                        break;
                }
            }

            return option == 0 ? 'd' : 'w';
        }






    }
}
