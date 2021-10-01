using GoldBadgeChallenge_7_Barbeque.IFoodInterfaceAndClasses;
using GoldBadgeChallenge_7_Barbeque.ISweetsInterfaceAndClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_7_Barbeque
{
    public class BarbequeUI
    {
        BarbequeRepository _barbequeRepo = new BarbequeRepository();
        BurgerBoothRepo _burgerBoothRepo = new BurgerBoothRepo();
        IceCreamBoothRepo _iceCreamBoothRepo = new IceCreamBoothRepo();
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
            Console.WriteLine("Welcome to the Komodo Barbeque Log\n\n"
               + "What would you like to do?\n"
               + "1. Add a barbeque \n"
               + "2. View all of the barbeques\n"
               + "3. Average ticket price for all barbeques\n"           
               + "4. Exit the program\n");
            int mainInput = int.Parse(Console.ReadLine());
                switch (mainInput)
                {
                    case 1:
                        CreateABarbeque();
                        break;
                    case 2:
                        DisplayBarbeques();
                        break;
                    case 3:
                        FindTheAverageTicketPriceForAllBarbeques();
                        break;                    
                    case 4:
                        Console.WriteLine("GoodBye!");
                        System.Threading.Thread.Sleep(2000);
                        isRunning = false;
                        break;                   
                    default:
                        Console.WriteLine("Please enter a valid option...");
                        PressAnyKey();
                        break;
                }
            }
        } 
        public void CreateABarbeque()
        {
            Barbeque newBBQ = new Barbeque();
            Console.Clear();
            Console.WriteLine("What day ( 1 - 31 ) did the Barbeque happen on? ");
            int bbqDay = int.Parse(Console.ReadLine());
            Console.WriteLine("What month was it in ( 1 - 12 )? ");
            int bbqMonth = int.Parse(Console.ReadLine());
            Console.WriteLine("What year was it in (ex. 2020)");
            int bbqyear = int.Parse(Console.ReadLine());
            newBBQ.DayOfEvent = new DateTime(bbqyear, bbqMonth, bbqDay);
            Console.Clear();
            Console.WriteLine("Have you already created the Burger Booth for this barbeque? ( y / n )");
            string burgerBoothInput = Console.ReadLine().ToLower();
            if (burgerBoothInput == "y")
            {
                newBBQ.BurgerBooth = PickABurgerBooth();
                Console.WriteLine("We've add your burger booth.");
                PressAnyKey();
            }
            else if (burgerBoothInput == "n")
            {
                newBBQ.BurgerBooth = CreateANewBurgerBooth();
                PressAnyKey();
            }
            else
            {
                YesOrNoDefault();
            }
            Console.WriteLine("Have you already created an Ice Cream Booth for this barbeque? ( y / n )");
            string iceCreamBoothInput = Console.ReadLine().ToLower();
            if (iceCreamBoothInput == "y")
            {
                newBBQ.IceCreamBooth = PickAnIceCreamBooth();
                Console.WriteLine("We've add your ice cream booth.");
                PressAnyKey();
            }
            else if (iceCreamBoothInput == "n")
            {
                newBBQ.IceCreamBooth = CreateANewIceCreamBooth();
                PressAnyKey();
            }
            else
            {
                YesOrNoDefault();
            }
            if (newBBQ != null)
            {
                _barbequeRepo.CreateACompanyBarbeque(newBBQ);
                Console.WriteLine("The barbeque has been created!");
                PressAnyKey();
            }
            else
            {
                Console.WriteLine("Looks like something went wrong");
                PressAnyKey();
            }
        }
        public void DisplayBarbeques()
        {
            Console.Clear();
            foreach (Barbeque barbeque in _barbequeRepo.SeeAllBarbeques())
            {
                Console.WriteLine($"Barbeque ID number: {barbeque.ID}\n"
                    + $"Day of the barbeque: {barbeque.DayOfEvent}\n"
                    + $"Burger booth used: {barbeque.BurgerBooth.Name}\n"
                    + $"    Total cost of the burger booth ${barbeque.BurgerBooth.FoodPrice}\n"
                    + $"    Total number of employee tickets taken at this booth: {barbeque.BurgerBooth.TicketsTaken}\n"
                    + $"Ice Cream booth used: {barbeque.IceCreamBooth.Name}\n"
                    + $"    Total cost of the ice cream booth: ${barbeque.IceCreamBooth.SweetsPrice}\n"
                    + $"    Total number of employee tickets taken at this booth: {barbeque.IceCreamBooth.TicketsTaken}\n"
                    + $"Total Cost of the Event: ${barbeque.IceCreamBooth.SweetsPrice + barbeque.BurgerBooth.FoodPrice}\n");
            }
            PressAnyKey();
        }
        public BarbequeBurgerBooth PickABurgerBooth()
        {
            foreach (BarbequeBurgerBooth burgerBooth in _burgerBoothRepo.SeeAllBurgerBooths())
            {
                Console.WriteLine($"Burger booth ID : {burgerBooth.ID}          Burger booth name : {burgerBooth.Name}          Burger booth price: {burgerBooth.FoodPrice}");
            }
            Console.WriteLine("\n\n Please enter the ID of the burger booth you want to add.");
            int boothID = int.Parse(Console.ReadLine());
            BarbequeBurgerBooth chosenBooth = _burgerBoothRepo.FindBurgerBoothById(boothID);
            return chosenBooth;
        }
        public BarbequeBurgerBooth CreateANewBurgerBooth()
        {
            BarbequeBurgerBooth newBurgerBooth = new BarbequeBurgerBooth();
            Console.WriteLine("What was the name of the burger booth?");
            newBurgerBooth.Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("How many tickets were taken for hamburgers?");
            int burgerTickets = int.Parse(Console.ReadLine());
            Console.WriteLine("How many tickets were taken for veggie burgers?");
            int veggieBurgerTickets = int.Parse(Console.ReadLine());
            Console.WriteLine("How many tickets were taken for hot dogs?");
            int hotDogTickets = int.Parse(Console.ReadLine());
            newBurgerBooth.TicketsTaken = burgerTickets + veggieBurgerTickets + hotDogTickets;
            var hamburger = new Hamburger();
            var veggieBurger = new VeggieBurger();
            var hotDog = new HotDog();
            newBurgerBooth.FoodPrice = (burgerTickets * hamburger.Price) + (veggieBurgerTickets * veggieBurger.Price) + (hotDogTickets * hotDog.Price);
            if (newBurgerBooth != null)
            {
                Console.WriteLine("The burger booth was added.");
                _burgerBoothRepo.CreateABurgerBooth(newBurgerBooth);
                return newBurgerBooth;
            }
            else
            {
                Console.WriteLine("Burger booth could not be added");
                return null;
            }
        }
        public BarbequeIceCreamBooth CreateANewIceCreamBooth()
        {
            BarbequeIceCreamBooth newBooth = new BarbequeIceCreamBooth();
            Console.WriteLine("What was the name of the ice cream booth?");
            newBooth.Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("How many tickets were taken for ice cream cones?");
            int iceCreamTickets = int.Parse(Console.ReadLine());
            Console.WriteLine("How many tickets were taken for popcorn?");
            int popcornTickets = int.Parse(Console.ReadLine());
            newBooth.TicketsTaken = iceCreamTickets + popcornTickets;
            var iceCream = new IceCream();
            var popcorn = new Popcorn();
            newBooth.SweetsPrice = (popcornTickets * popcorn.Price) + (iceCreamTickets * iceCream.Price);
            if (newBooth != null)
            {
                Console.WriteLine("The ice cream booth was added.");
                _iceCreamBoothRepo.CreateAnIceCreamBooth(newBooth);
                return newBooth;
            }
            else
            {
                Console.WriteLine("Ice Cream booth could not be added");
                return null;
            }
        }
        public BarbequeIceCreamBooth PickAnIceCreamBooth()
        {
            foreach (BarbequeIceCreamBooth booth in _iceCreamBoothRepo.SeeAllIceCreamBooths())
            {
                Console.WriteLine($"Burger booth ID : {booth.ID}          Burger booth name : {booth.Name}          Burger booth price: {booth.SweetsPrice}");
            }
            Console.WriteLine("\n\n Please enter the ID of the ice cream booth you want to add.");
            int boothID = int.Parse(Console.ReadLine());
            BarbequeIceCreamBooth chosenBooth = _iceCreamBoothRepo.FindIceCreamBoothById(boothID);
            return chosenBooth;
        }
        public void FindTheAverageTicketPriceForAllBarbeques()
        {
            decimal totalBurgerPrice = default;
            int burgerTicketCount = default;
            foreach (BarbequeBurgerBooth burgerBooth in _burgerBoothRepo.SeeAllBurgerBooths())
            {
                totalBurgerPrice += burgerBooth.FoodPrice;
                burgerTicketCount += burgerBooth.TicketsTaken;
            }
            decimal totalIceCreamPrice = default;
            int iceCreamTicketCount = default;            
            foreach(BarbequeIceCreamBooth iceCreamBooth in _iceCreamBoothRepo.SeeAllIceCreamBooths())
            {
                totalIceCreamPrice += iceCreamBooth.SweetsPrice;
                iceCreamTicketCount += iceCreamBooth.TicketsTaken;
            }
            decimal averageBurgerTicketPrice = Math.Round( totalBurgerPrice / burgerTicketCount, 2);
            decimal averageIceCreamTicketPrice = Math.Round(totalIceCreamPrice / iceCreamTicketCount, 2);
            Console.Clear();
            Console.WriteLine($"You have had a burger booth at {_burgerBoothRepo.SeeAllBurgerBooths().Count} barbeques.\n"
                + $"They collect a total of {burgerTicketCount} tickets during all of the barbeques.\n"
                + $"    You've spent ${totalBurgerPrice} for the burger booths.\n"
                + $"    The average cost per ticket is : ${averageBurgerTicketPrice}.\n"
                + $"You have had an ice cream booth at {_iceCreamBoothRepo.SeeAllIceCreamBooths().Count} barbeques.\n"
                + $"    They collect a total of {iceCreamTicketCount} tickets during all of the barbeques.\n"
                + $"    You've spent ${totalIceCreamPrice} for the burger booths.\n"
                + $"    The average cost per ticket is : ${averageIceCreamTicketPrice}.");
            PressAnyKey();
        }
        public void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }
        public void YesOrNoDefault()
        {
            Console.WriteLine("Please enter a (y) or a (n)... ");
            PressAnyKey();
        }
        public void SeedData()
        {
            Barbeque firstBBQ = new Barbeque();
            Barbeque secondBBQ = new Barbeque();
            BarbequeBurgerBooth mrBeastBurger = new BarbequeBurgerBooth();
            BarbequeBurgerBooth fiveGuys = new BarbequeBurgerBooth();
            BarbequeIceCreamBooth jaysIceCream = new BarbequeIceCreamBooth();
            BarbequeIceCreamBooth jaysIceCream2 = new BarbequeIceCreamBooth();
            mrBeastBurger.FoodPrice = 665.23m;
            mrBeastBurger.Name = "Mr. Beast Burger";
            mrBeastBurger.TicketsTaken = 98;
            fiveGuys.FoodPrice = 953.64m;
            fiveGuys.Name = "Five Guys";
            fiveGuys.TicketsTaken = 149;
            jaysIceCream.Name = "Jay's Ice Cream";
            jaysIceCream.SweetsPrice = 412.52m;
            jaysIceCream.TicketsTaken = 98;
            jaysIceCream2.Name = "Jay's Ice Cream";
            jaysIceCream2.SweetsPrice = 578.43m;
            jaysIceCream2.TicketsTaken = 124;
            _burgerBoothRepo.CreateABurgerBooth(mrBeastBurger);
            _burgerBoothRepo.CreateABurgerBooth(fiveGuys);
            _iceCreamBoothRepo.CreateAnIceCreamBooth(jaysIceCream);
            _iceCreamBoothRepo.CreateAnIceCreamBooth(jaysIceCream2);
            firstBBQ.BurgerBooth = mrBeastBurger;
            secondBBQ.BurgerBooth = fiveGuys;
            firstBBQ.IceCreamBooth = jaysIceCream;
            secondBBQ.IceCreamBooth = jaysIceCream2;
            _barbequeRepo.CreateACompanyBarbeque(firstBBQ);
            _barbequeRepo.CreateACompanyBarbeque(secondBBQ);
                
        }
    }
}
