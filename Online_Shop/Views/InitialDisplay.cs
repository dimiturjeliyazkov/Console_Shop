using Online_Shop.Controllers;
using Online_Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shop.Views
{
    class InitialDisplay
    {
        public string Username = "admin";
        public string Password = "admin";
        bool isAdmin = false;

        public InitialDisplay()
        {
            while (true)
            {
                Console.Clear();
                UserOrAdmin();
            }

        }

        private void UserOrAdmin()
        {
            if (!isAdmin)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 5, 5);
                Console.Write("User");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(Console.WindowWidth / 2 + 5, 5);
                Console.Write("Admin");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 5, 5);
                Console.Write("User");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(Console.WindowWidth / 2 + 5, 5);
                Console.Write("Admin");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }



            ConsoleKeyInfo usr = Console.ReadKey();
            if (usr.Key == ConsoleKey.LeftArrow)
            {
                isAdmin = false;
            }
            if (usr.Key == ConsoleKey.RightArrow)
            {
                isAdmin = true;
            }
            if (usr.Key == ConsoleKey.Enter)
            {
                if (isAdmin)
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    if (Username == username && Password == password)
                    {
                        AdminDisplay adminDisplay = new AdminDisplay();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Wrong credentials!");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
                else
                {
                    UserDisplay userDisplay = new UserDisplay();
                }
            }



        }
    }
}
