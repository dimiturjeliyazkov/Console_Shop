using Online_Shop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shop.Views
{
    class UserDisplay
    {
        List<string> Options = new List<string>() { "Foods", "Drinks", "Desserts"};
        FoodController foodController = new FoodController();
        DrinkController drinkController = new DrinkController();
        DessertController dessertController = new DessertController();
        CartController cart = new CartController();

        int Pointer = 0;
        int CartIndex = 0;
        bool isInOption = true;
        bool isInFoods = false;
        bool isInDrinks = false;
        bool isInDesserts = false;
        public UserDisplay()
        {
            while (true)
            {
                Console.Clear();
                PrintHello();
                PrintOptions();
                PrintCart(Options.Count());
                ChangingThePositionOfPointer(Options.Count);
            }
        }
        private void TextMarking(string text)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(text);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void PrintText(string text, int x, int y, bool isMarked)
        {
            Console.SetCursorPosition(x, y);
            if (isMarked)
            {
                TextMarking(text);
            }
            else
            {
                Console.Write(text);
            }
        }
        private void PrintHello()
        {
            PrintText("Welcome, customer! What would you like to buy from us today?", 
                Console.WindowWidth / 2 - 18, 3, false);
        }
        private void PrintOptions()
        {
            for (int i = 0; i < Options.Count; i++)
            {
                if(Pointer == i)
                {
                    PrintText(Options[i], 1, Console.WindowHeight / 3 + i, true);
                }
                else
                {
                    PrintText(Options[i], 1, Console.WindowHeight / 3 + i, false);
                }
            }
        }
        private void PrintCart(int cartIndex)
        {
            if (Pointer == cartIndex)
            {
                PrintText("Open cart", 1, Console.WindowHeight - 2, true);
            }
            else
            {
                PrintText("Open cart", 1, Console.WindowHeight - 2, false);
            }
        }
        private void PrintFoods()
        {
            for (int i = 0; i < foodController.GetAll().Count; i++)
            {
                if (Pointer == i)
                {
                    PrintText($"{i + 1}. {foodController.GetAll()[i].Name} - {foodController.GetAll()[i].Price}lv.",1, Console.WindowHeight / 3 + i, true);
                }
                else
                {
                    PrintText($"{i + 1}. {foodController.GetAll()[i].Name} - {foodController.GetAll()[i].Price}lv.",1, Console.WindowHeight / 3 + i, false);
                }
            }
        }
        private void PrintDrinks()
        {
            for (int i = 0; i < drinkController.GetAll().Count; i++)
            {
                if (Pointer == i)
                {
                    PrintText($"{i + 1}. {drinkController.GetAll()[i].Name} - {drinkController.GetAll()[i].Price}lv.", 1, Console.WindowHeight / 3 + i, true);
                }
                else
                {
                    PrintText($"{i + 1}. {drinkController.GetAll()[i].Name} - {drinkController.GetAll()[i].Price}lv.", 1, Console.WindowHeight / 3 + i, false);
                }
            }
        }
        private void PrintDesseert()
        {
            for (int i = 0; i < dessertController.GetAll().Count; i++)
            {
                if (Pointer == i)
                {
                    PrintText($"{i + 1}. {dessertController.GetAll()[i].Name} - {dessertController.GetAll()[i].Price}lv.", 1, Console.WindowHeight / 3 + i, true);
                }
                else
                {
                    PrintText($"{i + 1}. {dessertController.GetAll()[i].Name} - {dessertController.GetAll()[i].Price}lv.", 1, Console.WindowHeight / 3 + i, false);
                }
            }
        }
        private void ClearOptions(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.SetCursorPosition(1, Console.WindowHeight / 3 + i);
                Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            }
       
        }
        private void ChangingThePositionOfPointer(int count)
        {
            ConsoleKeyInfo usr = Console.ReadKey();
            if (usr.Key == ConsoleKey.DownArrow && Pointer < count)
            {
                Pointer++;
            }
            else if (usr.Key == ConsoleKey.UpArrow && Pointer > 0)
            {
                Pointer--;
            }
            else if(usr.Key == ConsoleKey.Enter)
            {
                Enter();
            }
            else if(usr.Key == ConsoleKey.Escape)
            {
                UserDisplay user = new UserDisplay();
            }
        }
        private void Enter()
        {
            if (isInOption)
            {
                isInOption = false;
                if (Pointer == 0)
                {
                    isInFoods = true;
                    isInDrinks = false;
                    isInDesserts = false;
                    while (true)
                    {
                        ClearOptions(10);
                        PrintFoods();
                        PrintCart(foodController.GetAll().Count);
                        ChangingThePositionOfPointer(foodController.GetAll().Count);
                    }
                }
                else if (Pointer == 1)
                {
                    Pointer = 0;
                    isInDrinks = true;
                    isInFoods = false;
                    isInDesserts = false;
                    while (true)
                    { 
                        ClearOptions(10);
                        PrintDrinks();
                        PrintCart(drinkController.GetAll().Count);
                        ChangingThePositionOfPointer(drinkController.GetAll().Count);
                    }
                   
                }
                else if (Pointer == 2)
                {
                    Pointer = 0;
                    isInDrinks = false;
                    isInFoods = false;
                    isInDesserts = true;
                    while (true)
                    {
                        ClearOptions(10);
                        PrintDesseert();
                        PrintCart(dessertController.GetAll().Count);
                        ChangingThePositionOfPointer(dessertController.GetAll().Count);
                    }

                }
            }
            else if (isInFoods)
            {
                if(Pointer < foodController.GetAll().Count())
                {
                    ConsoleKeyInfo yOrn;
                    bool isLeft = true;
                    bool isRight = false;
                    while (true)
                    {
                        ClearOptions(Console.WindowHeight/2);
                        List<string> foodDetails = foodController.GetFoodDetails(Pointer);
                        for (int i = 0; i < foodDetails.Count(); i++)
                        {
                            Console.SetCursorPosition(1, Console.WindowHeight / 3 + i );
                            Console.Write(foodDetails[i]);
                        }
                        Console.SetCursorPosition(1, Console.WindowHeight / 3 + foodDetails.Count() + 2);
                        Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                        PrintText("Do you wish to add the product to your cart?", 1, Console.WindowHeight / 3 + foodDetails.Count()+1, false);
                        PrintText("Yes", 1, Console.WindowHeight / 3 + foodDetails.Count() + 2, isLeft);
                        PrintText("or", 1 + 4, Console.WindowHeight / 3 + foodDetails.Count() + 2, false);
                        PrintText("No", 1 + 8, Console.WindowHeight / 3 + foodDetails.Count() + 2, isRight);
                        yOrn = Console.ReadKey();


                        if (yOrn.Key == ConsoleKey.RightArrow)
                        {
                            isLeft = false;
                            isRight = true;
                        }
                        else if (yOrn.Key == ConsoleKey.LeftArrow)
                        {
                            isLeft = true;
                            isRight = false;
                        }
                        else if (yOrn.Key == ConsoleKey.Enter)
                        {
                            if (isLeft)
                            {
                                if (!cart.ifAlreadyExists(foodController.GetAll()[Pointer].Name))
                                {
                                    cart.CreateCartProduct(foodController.GetAll()[Pointer].Name, foodController.GetAll()[Pointer].Price,
                                    foodController.GetAll()[Pointer].Description, foodController.GetAll()[Pointer].WeightInGr);
                                    PrintText("Succsesfuly Added To Cart.", 1, Console.WindowHeight / 3 + +foodDetails.Count() + 2, true);
                                    System.Threading.Thread.Sleep(1000);
                                    
                                }
                                else
                                {
                                    foreach (var item in cart.GetAll())
                                    {
                                        if(item.Name == foodController.GetAll()[Pointer].Name)
                                        {
                                            cart.increaseNumber(item.Id);
                                            PrintText("Succsesfuly increas the product.", 1, Console.WindowHeight / 3 + +foodDetails.Count() + 2, true);
                                            System.Threading.Thread.Sleep(1000);
                                        }
                                    }
                                }
                               
                            }
                            else if (isRight)
                            {
                                break;
                            }
                        }
                        else if(yOrn.Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                    }

                }
                
            }
            else if (isInDrinks)
            {
                if (Pointer < drinkController.GetAll().Count())
                {
                    ConsoleKeyInfo yOrn;
                    bool isLeft = true;
                    bool isRight = false;
                    while (true)
                    {
                        ClearOptions(Console.WindowHeight / 2);
                        List<string> drinkDetails = drinkController.GetDrinkDetails(Pointer);
                        for (int i = 0; i < drinkDetails.Count(); i++)
                        {
                            Console.SetCursorPosition(1, Console.WindowHeight / 3 + i);
                            Console.Write(drinkDetails[i]);
                        }
                        Console.SetCursorPosition(1, Console.WindowHeight / 3 + drinkDetails.Count() + 2);
                        Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                        PrintText("Do you wish to add the product to your cart?", 1, Console.WindowHeight / 3 + drinkDetails.Count() + 1, false);
                        PrintText("Yes", 1, Console.WindowHeight / 3 + drinkDetails.Count() + 2, isLeft);
                        PrintText("or", 1 + 4, Console.WindowHeight / 3 + drinkDetails.Count() + 2, false);
                        PrintText("No", 1 + 8, Console.WindowHeight / 3 + drinkDetails.Count() + 2, isRight);
                        yOrn = Console.ReadKey();


                        if (yOrn.Key == ConsoleKey.RightArrow)
                        {
                            isLeft = false;
                            isRight = true;
                        }
                        else if (yOrn.Key == ConsoleKey.LeftArrow)
                        {
                            isLeft = true;
                            isRight = false;
                        }
                        else if (yOrn.Key == ConsoleKey.Enter)
                        {
                            if (isLeft)
                            {
                                if (!cart.ifAlreadyExists(drinkController.GetAll()[Pointer].Name))
                                {
                                    cart.CreateCartProduct(drinkController.GetAll()[Pointer].Name, drinkController.GetAll()[Pointer].Price,
                                    drinkController.GetAll()[Pointer].Description, drinkController.GetAll()[Pointer].WeightInMl);
                                    PrintText("Succsesfuly Added To Cart.", 1, Console.WindowHeight / 3 + +drinkDetails.Count() + 2, true);
                                    System.Threading.Thread.Sleep(1000);

                                }
                                else
                                {
                                    foreach (var item in cart.GetAll())
                                    {
                                        if (item.Name == drinkController.GetAll()[Pointer].Name)
                                        {
                                            cart.increaseNumber(item.Id);
                                            PrintText("Succsesfuly increas the product.", 1, Console.WindowHeight / 3 + +drinkDetails.Count() + 2, true);
                                            System.Threading.Thread.Sleep(1000);
                                        }
                                    }
                                }

                            }
                            else if (isRight)
                            {
                                break;
                            }
                        }
                        else if (yOrn.Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                    }

                }
            }
            else if (isInDesserts)
            {
                if (Pointer < dessertController.GetAll().Count())
                {
                    ConsoleKeyInfo yOrn;
                    bool isLeft = true;
                    bool isRight = false;
                    while (true)
                    {
                        ClearOptions(Console.WindowHeight / 2);
                        List<string> dessertDetails = dessertController.GetDessertDetails(Pointer);
                        for (int i = 0; i < dessertDetails.Count(); i++)
                        {
                            Console.SetCursorPosition(1, Console.WindowHeight / 3 + i );
                            Console.Write(dessertDetails[i]);
                        }
                        Console.SetCursorPosition(1, Console.WindowHeight / 3 + dessertDetails.Count() + 2);
                        Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                        PrintText("Do you wish to add the product to your cart?", 1, Console.WindowHeight / 3 + dessertDetails.Count() + 1, false);
                        PrintText("Yes", 1, Console.WindowHeight / 3 + dessertDetails.Count() + 2, isLeft);
                        PrintText("or", 1 + 4, Console.WindowHeight / 3 + dessertDetails.Count() + 2, false);
                        PrintText("No", 1 + 8, Console.WindowHeight / 3 + dessertDetails.Count() + 2, isRight);
                        yOrn = Console.ReadKey();


                        if (yOrn.Key == ConsoleKey.RightArrow)
                        {
                            isLeft = false;
                            isRight = true;
                        }
                        else if (yOrn.Key == ConsoleKey.LeftArrow)
                        {
                            isLeft = true;
                            isRight = false;
                        }
                        else if (yOrn.Key == ConsoleKey.Enter)
                        {
                            if (isLeft)
                            {
                                if (!cart.ifAlreadyExists(dessertController.GetAll()[Pointer].Name))
                                {
                                    cart.CreateCartProduct(dessertController.GetAll()[Pointer].Name, dessertController.GetAll()[Pointer].Price,
                                    dessertController.GetAll()[Pointer].Description, dessertController.GetAll()[Pointer].WeightInGr);
                                    PrintText("Succsesfuly Added To Cart.", 1, Console.WindowHeight / 3 + +dessertDetails.Count() + 2, true);
                                    System.Threading.Thread.Sleep(1000);

                                }
                                else
                                {
                                    foreach (var item in cart.GetAll())
                                    {
                                        if (item.Name == dessertController.GetAll()[Pointer].Name)
                                        {
                                            cart.increaseNumber(item.Id);
                                            PrintText("Succsesfuly increas the product.", 1, Console.WindowHeight / 3 + +dessertDetails.Count() + 2, true);
                                            System.Threading.Thread.Sleep(1000);
                                        }
                                    }
                                }

                            }
                            else if (isRight)
                            {
                                break;
                            }
                        }
                        else if (yOrn.Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                    }

                }
            }
        }

    }
}
