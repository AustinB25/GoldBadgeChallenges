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
            SeedData();
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
                        ViewAllMenuItems();
                        break;
                    case 3:
                        ViewASpecificItem();
                        break;
                    case 4:
                        RemoveAnItem();
                        break;
                    case 5:
                        Console.WriteLine("Goodbye!");
                        System.Threading.Thread.Sleep(2000);
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("You did not enter a valid number...");
                        PressAnyKey();
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
        public void ViewAllMenuItems()
        {
            Console.Clear();
            foreach(CafeMenuItem item in _menuItems.SeeAllMenuItems())
            {
                Console.WriteLine($"Item ID: {item.ID}          Item name: {item.Name}          Price of the item: {item.Price}\n"
                    + $"Description: {item.Description}\n");
            }
        }
        public void ViewASpecificItem()
        {
            Console.Clear();
            ViewAllMenuItems();
            Console.WriteLine("\n Please enter the item ID of the item you want to view");
            int itemID = int.Parse(Console.ReadLine());
            Console.Clear();
            CafeMenuItem item = _menuItems.FindItemByID(itemID);
            Console.WriteLine($"Item ID: {item.ID}          Item name: {item.Name}          Price of the item: {item.Price}\n"
                    + $"Description: {item.Description}\n"
                    + $"Ingredients: ");
            DisplayListOfStrings(item.Ingredients);
            PressAnyKey();
        }
        public void RemoveAnItem()
        {
            ViewAllMenuItems();
            Console.WriteLine("\nPlease enter the id of the item you want to remove.");
            int removeItem = int.Parse(Console.ReadLine());
            Console.Clear();
            bool wasRemoved = _menuItems.RemoveAMenuItem(removeItem);
            if(wasRemoved == false)
            {
                Console.WriteLine("The item could not be removed");
                PressAnyKey();
            }
            if(wasRemoved == true)
            {
                Console.WriteLine("Your item was removed from the menu.");
                PressAnyKey();
            }
        }
        public void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        public List<string> DisplayListOfStrings(List<string> list)
        {
            int listNumber = 1;
            foreach(string item in list)
            {
                Console.WriteLine($"                {listNumber}. {item}");
                listNumber++;
            }
            return list;
        }
        public void SeedData()
        {
            CafeMenuItem seed1 = new CafeMenuItem("Eggs and Cheese", "Fresh plate of eggs and cheese", 1.75m);
            List<string> ingredients = new List<string>();
            ingredients.Add("eggs");
            ingredients.Add("cheese");
            seed1.Ingredients = ingredients;
            CafeMenuItem seed2 = new CafeMenuItem("Bacon, Eggs, and Cheese", "Fresh plate of bacon, eggs, and cheese", 3.75m);
            List<string> ingredients2 = new List<string>();
            ingredients2.Add("eggs");
            ingredients2.Add("cheese");
            ingredients2.Add("bacon");
            seed1.Ingredients = ingredients;
            seed2.Ingredients = ingredients2;
            _menuItems.CreateAMenuItem(seed1);
            _menuItems.CreateAMenuItem(seed2);
        }
    }
}
