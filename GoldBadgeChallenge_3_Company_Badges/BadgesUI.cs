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
                        break;
                    case 3:
                        ViewAllBadgesUI();
                        break;
                    case 4:
                        break;
                    default:
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
                    Console.WriteLine("Invalid input");
                }
            } while (addingDoors);
        }
        public void ViewAllBadgesUI()
        {
            Console.Clear();
            Console.WriteLine($"Badge #     Door Access\n");
            foreach (KeyValuePair<int, Badge> badge in _badgeRepo.ViewAllBadges())
            {

                Console.WriteLine($"{badge.Key}     {badge.Value.DoorAccess}");
            }
            Console.WriteLine("\n");
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
        public void DisplayDoorAccess()
        {

            foreach (KeyValuePair<int, Badge> badgeAccess in _badgeRepo.ViewAllBadges())
            {
                Console.WriteLine($"");
            }
        }
       

        /*   The Program will allow a security staff member to do the following:
create a new badge
update doors on an existing badge.
delete all doors from an existing badge.
show a list with all badge numbers and door access
Note: Make sure to keep the responsibilities of your UI, your repo, and your tests separate.
Only your UI class should ever take input from the user.
Here are some example views:
Menu
Hello Security Admin, What would you like to do?
Add a badge
Edit a badge.
List all Badges
#1 Add a badge
What is the number on the badge: 12345
List a door that it needs access to: A5
Any other doors(y/n)? y
List a door that it needs access to: A7
Any other doors(y/n)? n
(Return to main menu.)
#2 Update a badge
What is the badge number to update? 12345
12345 has access to doors A5 & A7.
What would you like to do?
Remove a door
Add a door
> 1
Which door would you like to remove? A5
Door removed.
12345 has access to door A7.
#3 List all badges view
Badge #	Door Access
12345	A7
22345	A1, A4, B1, B2
32345	A4, A5
Out of scope:
You do not need to consider tying an individual badge to a particular user. Just the Badge # will do.
Be sure to Unit Test your Repository methods.*/
    }
}
