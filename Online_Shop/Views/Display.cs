using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shop.Views
{
    class Display
    {
        private static List<string> Options = new List<string>() { "Food", "Drinks", "Desserts" };
        private static int Pointer = 0;
        public Display()
        {

            while (true)
            {
                PrintTheIntroduction();
                ViewTheOptions();
                PrintExtencions("Cart", Console.WindowWidth / 3, Console.WindowHeight - 1, Options.Count);
                PrintExtencions("ADMIN", Console.WindowWidth / 2, Console.WindowHeight - 1, Options.Count+1);
                MovingThePosition();
               // System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }
        static void PrintTheIntroduction()
        {
            Console.SetCursorPosition(Console.WindowWidth/3, 1);
            Console.Write("Welcome to Our Shop!");
            Console.SetCursorPosition(Console.WindowWidth / 3, 2);
            Console.Write("What would you like to buy from us today?");
        }
        static void ViewTheOptions()
        {
            for (int i = 0; i < Options.Count; i++)
            {
                Console.SetCursorPosition(2,7+i*2);
                if(Pointer == i)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write(Options[i]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
           
        }
        static void PrintExtencions(string Name,int x,int y,int count)
        {
            Console.SetCursorPosition(x, y);//Console.WindowWidth / 3, Console.WindowHeight - 1
            if(Pointer == count)//Options.Count
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            Console.Write(Name);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void MovingThePosition()
        {
            ConsoleKeyInfo usr = Console.ReadKey();
            if (usr.Key == ConsoleKey.DownArrow && Pointer < Options.Count)
            {
                Pointer++;

            }
            else if (usr.Key == ConsoleKey.UpArrow && Pointer > 0 && Pointer != Options.Count+1)
            {
                Pointer--;
            }
            else if(usr.Key == ConsoleKey.RightArrow && Pointer == Options.Count)
            {
                Pointer++;
            }
            else if (usr.Key == ConsoleKey.LeftArrow && (Pointer == Options.Count+1 || Pointer == Options.Count))
            {
                Pointer--;
            }
        }
        static void EnteringThePosition()
        {

        }
    }
}
