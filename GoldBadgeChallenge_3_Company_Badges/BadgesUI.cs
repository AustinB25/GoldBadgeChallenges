using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_3_Company_Badges
{
    public class BadgesUI
    {
        BadgesRepo _badgeRepo = new BadgesRepo();
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
                Console.WriteLine("Hello Security Admin, What would you like to do?\n"
                    + "1. Add a badge\n"
                    + "2. Edit a badge\n"
                    + "3. List all badges\n"
                    + "4. Exit the program");
                int mainInput = int.Parse(Console.ReadLine());
                switch (mainInput)
                {
                    case 1:
                        CreateABadgeUI();
                        break;
                    case 2:
                        UpdateABadge();
                        break;
                    case 3:
                        ViewAllBadgesUI();
                        break;
                    case 4:
                        Console.WriteLine("GoodBye!");
                        System.Threading.Thread.Sleep(2000);
                        isRunning = false;
                        break;
                    default:
                        SwitchDefault();
                        break;
                }
            }
        }
        public void CreateABadgeUI()
        {
            Badge newBadge = new Badge();
            List<string> doorAccess = new List<string>();
            Console.WriteLine("What is the badge Id:");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the name of the person that will have this badge?");
            newBadge.Name = Console.ReadLine();
            bool addingDoors = true;
            do
            {
                Console.WriteLine($"List a door {newBadge.Name} needs access to:");
                doorAccess.Add(Console.ReadLine());
                Console.WriteLine("Any other doors? ( y / n )");
                string anotherDoor = Console.ReadLine();
                if (anotherDoor == "y")
                {
                    addingDoors = true;
                }
                if (anotherDoor == "n")
                {
                    newBadge.DoorAccess = doorAccess;
                    addingDoors = false;
                    PressAnyKey();
                }
                if (anotherDoor == null)
                {
                    SwitchDefault();
                }
            } while (addingDoors);
            _badgeRepo.CreateANewBadge(newBadge);
        }        
        public void ViewAllBadgesUI()
        {
            Console.Clear();
            Console.WriteLine($"Badge #     Door Access\n");
            foreach (KeyValuePair<int, Badge> badge in _badgeRepo.ViewAllBadges())
            {

                Console.Write($"{badge.Key} "); DisplayDoorAccess(badge.Key);

            }
            Console.WriteLine("\n");
            PressAnyKey();
        }
        public void DisplayDoorAccess(int id)
        {
            Badge badgeList = _badgeRepo.FindBadgeByBadgeNumber(id);
            List<string> doorAccess = badgeList.DoorAccess;
            foreach (string door in doorAccess)
            {
                Console.Write($"{door}, ");
            }
            Console.WriteLine("\n");
        }
        public void UpdateABadge()
        {
            Badge newBadge = new Badge();
            Console.WriteLine("Please enter the badge Id that you want to update:");
            int badgeID = int.Parse(Console.ReadLine());
            Badge updateBadge = _badgeRepo.FindBadgeByBadgeNumber(badgeID);
            Console.WriteLine($"{updateBadge.BadgeID} has access to doors: ");
            DisplayDoorAccess(badgeID);
            Console.WriteLine("Would you like to:\n"
                + "1. Add a door\n"
                + "2. Remove a door");
            int doorUpdate = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (doorUpdate)
            {
                case 1:
                    updateBadge.DoorAccess = AddDoors(updateBadge);
                    break;
                case 2:
                    updateBadge.DoorAccess = RemoveDoor(updateBadge);
                    break;
                default:
                    SwitchDefault();
                    break;
            }
            Console.Clear();
            Console.WriteLine($"{updateBadge.BadgeID} has access to doors: ");
            DisplayDoorAccess(badgeID);
            PressAnyKey();
        }
        public List<string> AddDoors(Badge badge)
        {
            bool adding = true;
            List<string> newDoors = badge.DoorAccess;
            Console.WriteLine("Please enter the door you want to add");
            string door = Console.ReadLine();
            newDoors.Add(door);
            do
            {
                Console.WriteLine("Would you like to add another? ( y / n)");
                string addAnother = Console.ReadLine().ToLower();
                switch (addAnother)
                {
                    case "y":
                        Console.WriteLine("Please enter the door you want to add");
                        string nextDoor = Console.ReadLine();
                        newDoors.Add(nextDoor);
                        break;
                    case "n":
                        Console.WriteLine("The door has been added");
                        adding = false;
                        break;
                    default:
                        SwitchDefault();
                        break;
                }
            } while (adding);
            return newDoors;
        }        
        public List<string> RemoveDoor(Badge badge)
        {
            bool removing = true;
            Badge removeDoorFrom = _badgeRepo.FindBadgeByBadgeNumber(badge.BadgeID);            
            Console.WriteLine("Please enter the door you would like to remove:");
            string removeDoor = Console.ReadLine();            
            removeDoorFrom.DoorAccess.Remove(removeDoor);            
            do
            {
                Console.WriteLine("Would you like to remove another? ( y / n )");
                string removeAnother = Console.ReadLine().ToLower();
                switch (removeAnother)
                {
                    case "y":
                        Console.WriteLine("Please enter the door you want to remove");
                        string nextDoor = Console.ReadLine();
                        removeDoorFrom.DoorAccess.Remove(nextDoor);
                        break;
                    case "n":
                        Console.WriteLine("The door has been removed");
                        removing = false;
                        break;
                    default:
                        SwitchDefault();
                        break;
                }
            } while (removing);
            return removeDoorFrom.DoorAccess;
        }
        public void SwitchDefault()
        {
            Console.WriteLine("Invalid input");
            PressAnyKey();
        }
        public void SeedData()
        {
            Badge badge1 = new Badge();
            Badge badge2 = new Badge();
            List<string> doorAccess = new List<string>();
            List<string> doorAccess2 = new List<string>();
            doorAccess.Add("A1");
            doorAccess.Add("A2");
            doorAccess.Add("A3");
            doorAccess2.Add("B1");
            doorAccess2.Add("B2");
            doorAccess2.Add("B3");
            badge1.BadgeID = 51201;
            badge2.BadgeID = 51202;
            badge1.Name = "Austin";
            badge2.Name = "Katelyn";
            badge1.DoorAccess = doorAccess;
            badge2.DoorAccess = doorAccess2;
            _badgeRepo.CreateANewBadge(badge1);
            _badgeRepo.CreateANewBadge(badge2);
        }
        public void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }


    }
}
