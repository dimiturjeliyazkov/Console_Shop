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
        FoodController foodController = new FoodController();
        DrinkController drinkController = new DrinkController();
        DessertController dessertController = new DessertController();
        public int Pointer { get; set; }
        public bool exit = false;
        public int Count()
        {
            if(isInOptions)
            {
                return 2;
            }
            else if(isInFood)
            {
                return foodController.GetAll().Count();
            }
            else if (isInDrink)
            {
                return drinkController.GetAll().Count();
            }
            else
            {
                return dessertController.GetAll().Count();
            }
        }
        
        bool isInOptions = true;
        bool isInFood = false;
        bool isInDrink = false;
        bool isInDesserts = false;


        public AdminDisplay()
        {
            while (true)
            {
                Console.Clear();
                HelloText();
                if(isInOptions && !isInFood && !isInDrink && !isInDesserts)
                {
                    PrintProductOptions();
                }
                else if(!isInOptions && isInFood && !isInDrink && !isInDesserts)
                {
                    PrintFoods();
                    PrintMoreOptions("Add Food", 1, Console.WindowHeight - 2, foodController.GetAll().Count);
                }
                else if(!isInOptions && !isInFood && isInDrink && !isInDesserts)
                {
                    PrintDrinks();
                    PrintMoreOptions("Add drink", 1, Console.WindowHeight - 2, drinkController.GetAll().Count());
                }
                else if (!isInOptions && !isInFood && !isInDrink && isInDesserts)
                {
                    PrintDesserts();
                    PrintMoreOptions("Add dessert", 1, Console.WindowHeight - 2, dessertController.GetAll().Count());
                }
                NavigateThrowText();
                if (exit) break;
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
        private void PrintProductOptions()
        {
            PrintMoreOptions("Foods", 1, Console.WindowHeight / 3, 0);
            PrintMoreOptions("Drinks", 1, Console.WindowHeight / 3+1, 1);
            PrintMoreOptions("Desserts", 1, Console.WindowHeight / 3+2, 2);
        }
        private void PrintFoods()
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
        private void PrintDrinks()
        {

            for (int i = 0; i < drinkController.GetAll().Count; i++)
            {
                Console.SetCursorPosition(1, Console.WindowHeight / 3 + i);
                string text = $"{i + 1}. {drinkController.GetAll()[i].Name} - {drinkController.GetAll()[i].Price}lv.";
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
        private void PrintDesserts()
        {
            for (int i = 0; i < dessertController.GetAll().Count; i++)
            {
                Console.SetCursorPosition(1, Console.WindowHeight / 3 + i);
                string text = $"{i + 1}. {dessertController.GetAll()[i].Name} - {dessertController.GetAll()[i].Price}lv.";
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
        private void PrintMoreOptions(string text, int x, int y, int index)
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
            if (usr.Key == ConsoleKey.DownArrow&&Pointer<Count())
            {
                Pointer++;
            }
            if (usr.Key == ConsoleKey.UpArrow&&Pointer>0)
            {
                Pointer--;
            }


            if (usr.Key == ConsoleKey.Enter)
            {
                
                if (Pointer < foodController.GetAll().Count && isInFood == true)
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
                            Console.Write(" Delete View");
                        }
                        else if(UorDpointer == 1)
                        {
                            Console.Write("Update ");
                            MarkTheText("Delete");
                            Console.Write(" View");
                        }
                        else
                        {
                            Console.Write("Update Delete ");
                            MarkTheText("View");
                        }

                        ConsoleKeyInfo UorD = Console.ReadKey();
                        if (UorD.Key == ConsoleKey.RightArrow && UorDpointer < 2)
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
                            else if(UorDpointer == 2)
                            {
                                for (int i = 0; i < foodController.GetAll().Count(); i++)
                                {
                                    Console.SetCursorPosition(1, Console.WindowHeight / 3 + i);
                                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                                }
                                List<string>foodDetails = foodController.GetFoodDetails(Pointer);
                                for (int i = 0; i < foodDetails.Count(); i++)
                                {
                                    Console.SetCursorPosition(1, Console.WindowHeight / 3 + i+Pointer+1);
                                    Console.Write(foodDetails[i]);
                                }
                            }

                        }

                        else if(UorD.Key == ConsoleKey.Escape)
                        {
                            
                            break;
                        }
                    }  
                }
                else if (Pointer == foodController.GetAll().Count && isInFood == true)
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
                
                
                else if (Pointer < drinkController.GetAll().Count && isInDrink == true)
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
                            Console.Write(" Delete View");
                        }
                        else if (UorDpointer == 1)
                        {
                            Console.Write("Update ");
                            MarkTheText("Delete");
                            Console.Write(" View");
                        }
                        else
                        {
                            Console.Write("Update Delete ");
                            MarkTheText("View");
                        }

                        ConsoleKeyInfo UorD = Console.ReadKey();
                        if (UorD.Key == ConsoleKey.RightArrow && UorDpointer < 2)
                        {
                            UorDpointer++;
                        }
                        else if (UorD.Key == ConsoleKey.LeftArrow && UorDpointer > 0)
                        {
                            UorDpointer--;
                        }
                        else if (UorD.Key == ConsoleKey.Enter)
                        {
                            if (UorDpointer == 0)
                            {
                                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                                Console.Write("Updating the drink");
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
                                Console.Write("Enter new weight in mililiters: ");
                                int weightInGr = int.Parse(Console.ReadLine());
                                drinkController.UpdateDrink(Pointer.ToString(), name, price, description, weightInGr);
                                break;
                            }
                            else if (UorDpointer == 1)
                            {
                                drinkController.deleteDrink(Pointer.ToString());
                                break;
                            }
                            else if (UorDpointer == 2)
                            {
                                for (int i = 0; i < drinkController.GetAll().Count(); i++)
                                {
                                    Console.SetCursorPosition(1, Console.WindowHeight / 3 + i);
                                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                                }
                                List<string> drinkDetails = drinkController.GetDrinkDetails(Pointer);
                                for (int i = 0; i < drinkDetails.Count(); i++)
                                {
                                    Console.SetCursorPosition(1, Console.WindowHeight / 3 + i + Pointer + 1);
                                    Console.Write(drinkDetails[i]);
                                }
                            }

                        }

                        else if (UorD.Key == ConsoleKey.Escape)
                        {

                            break;
                        }
                    }
                }
                else if (Pointer == drinkController.GetAll().Count && isInDrink == true)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    Console.Write("Creating new drink");
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
                    Console.Write("Enter weight in militeres: ");
                    int weightInGr = int.Parse(Console.ReadLine());
                    drinkController.CreateDrink(name, price, description, weightInGr);
                }
                
                
                if (Pointer < dessertController.GetAll().Count && isInDesserts == true)
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
                            Console.Write(" Delete View");
                        }
                        else if (UorDpointer == 1)
                        {
                            Console.Write("Update ");
                            MarkTheText("Delete");
                            Console.Write(" View");
                        }
                        else
                        {
                            Console.Write("Update Delete ");
                            MarkTheText("View");
                        }

                        ConsoleKeyInfo UorD = Console.ReadKey();
                        if (UorD.Key == ConsoleKey.RightArrow && UorDpointer < 2)
                        {
                            UorDpointer++;
                        }
                        else if (UorD.Key == ConsoleKey.LeftArrow && UorDpointer > 0)
                        {
                            UorDpointer--;
                        }
                        else if (UorD.Key == ConsoleKey.Enter)
                        {
                            if (UorDpointer == 0)
                            {
                                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                                Console.Write("Updating the dessert");
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
                                dessertController.UpdateDessert(Pointer.ToString(), name, price, description, weightInGr);
                                break;
                            }
                            else if (UorDpointer == 1)
                            {
                                dessertController.deleteDessert(Pointer.ToString());
                                break;
                            }
                            else if (UorDpointer == 2)
                            {
                                for (int i = 0; i < dessertController.GetAll().Count(); i++)
                                {
                                    Console.SetCursorPosition(1, Console.WindowHeight / 3 + i);
                                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                                }
                                List<string> desseertDetails = dessertController.GetDessertDetails(Pointer);
                                for (int i = 0; i < desseertDetails.Count(); i++)
                                {
                                    Console.SetCursorPosition(1, Console.WindowHeight / 3 + i + Pointer + 1);
                                    Console.Write(desseertDetails[i]);
                                }
                            }

                        }

                        else if (UorD.Key == ConsoleKey.Escape)
                        {

                            break;
                        }
                    }
                }
                else if (Pointer == dessertController.GetAll().Count && isInDesserts == true)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    Console.Write("Creating new dessert");
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
                    dessertController.CreateDessert(name, price, description, weightInGr);
                }
                else if (Pointer == 0 && isInOptions)
                {
                    isInFood = true;
                    isInOptions = false;

                }
                else if (Pointer == 1 && isInOptions)
                {
                    Pointer = 0;
                    isInDrink = true;
                    isInOptions = false;
                }
                else if (Pointer == 2 && isInOptions)
                {
                    Pointer = 0;
                    isInDesserts = true;
                    isInOptions = false;
                }
            }
           
            else if(usr.Key == ConsoleKey.Escape )
            {
                if (isInOptions)
                {
                    exit = true;
                }
                else if(isInFood)
                {
                    isInOptions = true;
                    isInFood = false;
                }
                else if (isInDrink)
                {
                    isInOptions = true;
                    isInDrink = false;
                }
                else if (isInDesserts)
                {
                    isInOptions = true;
                    isInDesserts = false;
                }
            }
        }
    }
}
