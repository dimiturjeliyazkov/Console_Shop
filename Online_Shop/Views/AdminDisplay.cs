using Online_Shop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shop.Views
{
    class AdminDisplay
    {
        public int Pointer { get; set; }
        FoodController foodController = new FoodController();

        public AdminDisplay()
        {
            while (true)
            {
                Console.Clear();
                HelloText();
                PrintProducts();
                MoreOptions("Add Product", 1, Console.WindowHeight - 2, foodController.GetAll().Count);
                NavigateThrowText();

            }
        }
        private void MarkTheText(string text)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(text);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void HelloText()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 18, 3);
            Console.WriteLine("Welcome, boss! What changes shall we do today?");
        }
        private void PrintProducts()
        {

            for (int i = 0; i < foodController.GetAll().Count; i++)
            {
                Console.SetCursorPosition(1, Console.WindowHeight/3 + i);
                string text = $"{i+1}. {foodController.GetAll()[i].Name} - {foodController.GetAll()[i].Price}lv.";
                if (Pointer == i)
                {
                    MarkTheText(text);
                }
                else
                {
                    Console.WriteLine(text);
                }
            }
        }
        private void MoreOptions(string text, int x, int y, int index)
        {
            Console.SetCursorPosition(x, y);
            if (Pointer == index)
            {
                MarkTheText(text);
            }
            else
            {
                Console.Write(text);
            }
        }
        private void NavigateThrowText()
        {

            ConsoleKeyInfo usr = Console.ReadKey();
            if (usr.Key == ConsoleKey.DownArrow&&Pointer<foodController.GetAll().Count)
            {
                Pointer++;
            }
            if (usr.Key == ConsoleKey.UpArrow&&Pointer>0)
            {
                Pointer--;
            }
            if (usr.Key == ConsoleKey.Enter)
            {
                if (Pointer < foodController.GetAll().Count)
                {
                    int UorDpointer = 0;
                    while (true)
                    {
                        Console.SetCursorPosition(1, Console.WindowHeight / 3 + Pointer);
                        Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                        Console.SetCursorPosition(1, Console.WindowHeight / 3 + Pointer);
                        if (UorDpointer == 0)
                        {
                            MarkTheText("Update");
                            Console.Write(" or ");
                            Console.Write("Delete");
                        }
                        else
                        {
                            Console.Write("Update");
                            Console.Write(" or ");
                            MarkTheText("Delete");
                        }

                        ConsoleKeyInfo UorD = Console.ReadKey();
                        if (UorD.Key == ConsoleKey.RightArrow && UorDpointer < 1)
                        {
                            UorDpointer++;
                        }
                        else if (UorD.Key == ConsoleKey.LeftArrow && UorDpointer > 0)
                        {
                            UorDpointer--;
                        }
                        else if (UorD.Key == ConsoleKey.Enter)
                        {
                            if(UorDpointer == 0)
                            {
                                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                                Console.Write("Updating the food");
                                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + 1);
                                Console.Write("Enter new name: ");
                                string name = Console.ReadLine();
                                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + 2);
                                Console.Write("Enter new price: ");
                                double price = double.Parse(Console.ReadLine());
                                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + 3);
                                Console.Write("Enter new description: ");
                                string description = Console.ReadLine();
                                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + 4);
                                Console.Write("Enter new weight in grams: ");
                                int weightInGr = int.Parse(Console.ReadLine());
                                foodController.UpdateFood(Pointer.ToString(), name, price, description, weightInGr);
                                break;
                            }
                            else if(UorDpointer == 1)
                            {
                                foodController.deleteFood(Pointer.ToString());
                                break;
                            }
                        }
                    }
                    
                }
                else
                {
                    if (Pointer == foodController.GetAll().Count)
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                        Console.Write("Creating new food");
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + 1);
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + 2);
                        Console.Write("Enter price: ");
                        double price = double.Parse(Console.ReadLine());
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + 3);
                        Console.Write("Enter description: ");
                        string description = Console.ReadLine();
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + 4);
                        Console.Write("Enter weight in grams: ");
                        int weightInGr = int.Parse(Console.ReadLine());
                        foodController.CreateFood(name, price, description, weightInGr);
                    }
                }
            }

        }
    }
}
