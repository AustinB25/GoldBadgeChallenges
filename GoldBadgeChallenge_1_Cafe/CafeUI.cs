using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_1_Cafe
{
    public class CafeUI
    {
        private CafeMenuItemRepo _menuItems = new CafeMenuItemRepo();
        public void Run()
        {
            MainMenu();
        }
        public void MainMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine($"Welcome to the Cafe Menu Management System.\n\n"
                   + "What would you like to do?\n"
                   + "1. Create a new menu item\n"
                   + "2. View all menu items\n"
                   + "3. View a specific menu item\n"
                   + "4. Remove an item from the menu\n"
                   + "5. Leave the program");
                int mainInput = int.Parse(Console.ReadLine());
                switch (mainInput)
                {
                    case 1:
                        CreateMenuItem();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            }
        }
        public void CreateMenuItem()
        {
            Console.Clear();
            CafeMenuItem newItem = new CafeMenuItem();
            Console.WriteLine("What would you like to name this item?");
            newItem.Name = Console.ReadLine();
            Console.WriteLine("Please write a description of the menu item.");
            newItem.Description = Console.ReadLine();
            bool addingIngredients = true;
            do
            {
                List<string> ingredients = new List<string>();
                Console.Clear();                
                Console.WriteLine( "Would you like to add an ingredient? ( y / n)");
                string addAnother = Console.ReadLine().ToLower();
                if(addAnother == "y")
                {
                    Console.WriteLine("What ingredient would you like to add?");
                    string nextIngredient = Console.ReadLine();
                    ingredients.Add(nextIngredient);
                }
                else
                {
                    newItem.Ingredients = ingredients;
                    addingIngredients = false;
                }

            } while (addingIngredients);
            Console.WriteLine("How much is this item going to cost the customer? (ex 1.25)");
            newItem.Price = decimal.Parse(Console.ReadLine());
            if(newItem != null)
            {
            _menuItems.CreateAMenuItem(newItem);
                Console.WriteLine("Your new menu item has been added to the menu.");
                PressAnyKey();
            }
            else
            {
                Console.WriteLine("Menu item could not be added.");
                PressAnyKey();
            }
        }
        public void PressAnyKey()
        {
            Console.WriteLine("Press any key to conitue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
