using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenges_8_SmartInsurance
{
    public class SmartInsuranceUI
    {
        private DriverRepository _driverRepo = new DriverRepository();
        public void Run()
        {
            SeedData();
            MainMenu();
        }
        private void MainMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Welcome to the Komodo Insurance Premiums program!\n\n"
                    + "What would you like to do?\n"
                    + "1. Create a new Driver                                5. Update a driver\n"
                    + "2. See all drivers                                    6. Remove a driver\n"
                    + "3. View a specific driver information and premium     7. See the five best drivers\n"
                    + "4. View all driver rates                              8. Exit the program");
                int mainInput = int.Parse(Console.ReadLine());
                switch (mainInput)
                {
                    case 1:
                        bool wasAdded = _driverRepo.CreateANewDriver(CollectDriverInfo());
                        if (wasAdded == true)
                        {
                            Console.WriteLine("The new driver was created");
                            PressAnyKey();
                        }
                        else
                        {
                            Console.WriteLine("The driver was not created.");
                            PressAnyKey();
                        }
                        break;
                    case 2:
                        ViewAllDrivers();
                        PressAnyKey();
                        break;
                    case 3:
                        ViewADriver();
                        PressAnyKey();
                        break;
                    case 4:
                        DisplayDriverRates();
                        PressAnyKey();
                        break;
                    case 5:
                        UpdateADriver();
                        PressAnyKey();
                        break;
                    case 6:
                        DeleteADriver();
                        PressAnyKey();
                        break;
                    case 7:
                        DisplayTheBestDrivers();
                        PressAnyKey();
                        break;
                    case 8:
                        Console.WriteLine("Goodbye!");
                        System.Threading.Thread.Sleep(1500);
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        PressAnyKey();
                        break;
                }
            }
        }
        private Driver CollectDriverInfo()
        {
            Driver newD = new Driver();
            Console.WriteLine("What is the driver's first name?");
            newD.FirstName = Console.ReadLine();
            Console.WriteLine("What is the driver's last name?");
            newD.LastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Please enter the year {newD.FirstName} was born (ex. 1996)");
            int birthYear = int.Parse(Console.ReadLine());
            Console.WriteLine("The month ( 1- 12 )");
            int birthMonth = int.Parse(Console.ReadLine());
            Console.WriteLine("And the day ( 1 -31 )");
            int birthDay = int.Parse(Console.ReadLine());
            newD.BirthDate = new DateTime(birthYear, birthMonth, birthDay);
            Console.Clear();
            Console.WriteLine($"Do you know the average speed that {newD.FirstName} drives? ( y / n)");
            string dSpeed = Console.ReadLine().ToLower();
            if (dSpeed == "y")
            {
                Console.Clear();
                Console.WriteLine("What is the average speed?");
                newD.AverageSpeed = double.Parse(Console.ReadLine());
                PressAnyKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Okay we'll assume {newD.FirstName} is starting a new policy.");
                newD.AverageSpeed = 0.0;
                PressAnyKey();
            }
            Console.WriteLine($"Does {newD.FirstName} have any documented times over the speed limit? ( y / n)");
            string overSpeed = Console.ReadLine().ToLower();
            if (overSpeed == "y")
            {
                Console.WriteLine("How many times have they been over the speed limit?");
                newD.TimesOverSpeedLimit = int.Parse(Console.ReadLine());
                PressAnyKey();
            }
            else
            {
                Console.WriteLine("We'll give them the benifit of the doubt and assume they don't speed.");
                newD.TimesOverSpeedLimit = 0;
                PressAnyKey();
            }
            Console.WriteLine($"How many times did {newD.FirstName} report that they have crossed a road line? (Please enter a number)");
            newD.TimesCrossingLine = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine($"How many stop signs has {newD.FirstName} ran?");
            newD.StopSignsRan = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine($"How many times has {newD.FirstName} been reported for trailing a car?");
            newD.DriversTrailed = int.Parse(Console.ReadLine());
            PressAnyKey();
            newD.InsuranceRate = GetDriverPremium(newD);
            newD.DriverRating = GetDriverRating(newD);
            return newD;
        }
        private void ViewAllDrivers()
        {
            Console.Clear();
            var drivers = _driverRepo.SeeAllCoveredDrivers();
            Console.WriteLine("Driver Id        Name        Average Speed          Insurance premium");
            foreach (var d in drivers)
            {
                Console.WriteLine($"{d.DriverID}        {d.FullName}        {d.AverageSpeed}            ${d.InsuranceRate}");
            }
        }
        private void ViewADriver()
        {
            ViewAllDrivers();
            Console.WriteLine("\nPlease enter the driver id of the driver you want to view.");
            int dID = int.Parse(Console.ReadLine());
            Driver viewD = _driverRepo.FindASpecififcDriver(dID);
            Console.Clear();
            Console.WriteLine($"Driver name: {viewD.FullName}\n"
                + $"Driver birthday: {viewD.BirthDate}\n"
                + $"Average speed: {viewD.AverageSpeed}\n"
                + $"Times Speeding: {viewD.TimesOverSpeedLimit}\n"
                + $"Times crossing line: {viewD.TimesCrossingLine}\n"
                + $"Stop signs ran: {viewD.StopSignsRan}\n"
                + $"Drivers trailed: {viewD.DriversTrailed}\n"
                + $"Insurance premuim: ${viewD.InsuranceRate}");
        }
        private void UpdateADriver()
        {
            Console.Clear();
            ViewAllDrivers();
            Console.WriteLine("\nPlease enter the driver id of the diver you want to update.");
            int updateMe = int.Parse(Console.ReadLine());
            Driver updateDriver = CollectDriverInfo();
            bool wasUpdated = _driverRepo.UpdateADriver(updateMe, updateDriver);
            if (wasUpdated == true)
            {
                Console.WriteLine("The drivers infomation was updated.");
            }
            else
            {
                Console.WriteLine("The driver was not updated.");
            }
        }
        private void DeleteADriver()
        {
            Console.WriteLine("Please enter the driver id of the driver you want to delete.");
            int deleteMe = int.Parse(Console.ReadLine());
            bool wasDeleted = _driverRepo.RemoveADriver(deleteMe);
            if (wasDeleted == true)
            {
                Console.WriteLine("The driver was deleted");
            }
            else
            {
                Console.WriteLine("The driver was not deleted");
            }
        }
        private void DisplayDriverRates()
        {
            Console.Clear();
            Console.WriteLine("Driver name   Driver premium");
            foreach (var d in _driverRepo.SeeAllCoveredDrivers())
            {
                Console.WriteLine($"{d.FullName}     {d.InsuranceRate}");
            }
        }
        private void SeedData()
        {
            Driver seed1 = new Driver("Austin", "Bridgewater", new DateTime(1996, 8, 19), 35.0, 0, 0, 0, 0);
            Driver seed2 = new Driver("Katelyn", "Bridgewater", new DateTime(2016, 7, 20), 37.8, 21, 24, 4, 15);
            Driver seed3 = new Driver("Joey", "Kinney", new DateTime(2006, 6, 18), 59.6, 15, 20, 3, 48);
            Driver seed4 = new Driver("Garrett", "Sanders", new DateTime(1986, 5, 17), 26.9, 4, 10, 0, 3);
            Driver seed5 = new Driver("Jeremy", "Aldridge", new DateTime(1976, 4, 16), 36.2, 15, 42, 9, 12);
            Driver seed6 = new Driver("Jon", "Crowe", new DateTime(1946, 3, 15), 41.5, 26, 62, 23, 23);
            Driver seed7 = new Driver("Larry", "Hall", new DateTime(1956, 2, 14), 39.1, 30, 38, 15, 31);
            seed1.InsuranceRate = GetDriverPremium(seed1);
            seed2.InsuranceRate = GetDriverPremium(seed2);
            seed3.InsuranceRate = GetDriverPremium(seed3);
            seed4.InsuranceRate = GetDriverPremium(seed4);
            seed5.InsuranceRate = GetDriverPremium(seed5);
            seed6.InsuranceRate = GetDriverPremium(seed6);
            seed7.InsuranceRate = GetDriverPremium(seed7);
            seed1.DriverRating = GetDriverRating(seed1);
            seed2.DriverRating = GetDriverRating(seed2);
            seed3.DriverRating = GetDriverRating(seed3);
            seed4.DriverRating = GetDriverRating(seed4);
            seed5.DriverRating = GetDriverRating(seed5);
            seed6.DriverRating = GetDriverRating(seed6);
            seed7.DriverRating = GetDriverRating(seed7);
            _driverRepo.CreateANewDriver(seed1);
            _driverRepo.CreateANewDriver(seed2);
            _driverRepo.CreateANewDriver(seed3);
            _driverRepo.CreateANewDriver(seed4);
            _driverRepo.CreateANewDriver(seed5);
            _driverRepo.CreateANewDriver(seed6);
            _driverRepo.CreateANewDriver(seed7);
        }
        private List<Driver> FindTheFiveBestDrivers()
        {            
            var allDrivers = _driverRepo.SeeAllCoveredDrivers();
            var bestDrivers = new Driver[5];
            //loop 5 times to find 5 drivers
            for (int i = 0; i < 5; i++)
            {
                var currentBestDriver = allDrivers[0];
                bestDrivers[i] = allDrivers[0];
                for(int j =1; j < allDrivers.Count; j++)
                {
                    if(bestDrivers[i].DriverRating < allDrivers[j].DriverRating)
                    {
                        bestDrivers[i] = allDrivers[j];
                        currentBestDriver = bestDrivers[i];
                    }
                }
                    allDrivers.Remove(currentBestDriver);
            }    

            return bestDrivers.ToList();
        }
        private void DisplayTheBestDrivers()
        {
            Console.Clear();
            var bestDriverList = FindTheFiveBestDrivers();
            foreach (var driver in bestDriverList)
            {
                Console.WriteLine($"Driver Rating: {driver.DriverRating}\n"
                    + $" Driver Name: {driver.FullName}\n"
                    + $"Average Speed: {driver.AverageSpeed}\n");
            }
        }
        private int GetDriverRating(Driver d)
        {
            int speedRating = GetSpeedRating(d.AverageSpeed);
            int timesSpeedingRating = GetTimeSpeedingRating(d.TimesOverSpeedLimit);
            int crossedLineRating = LineCrossedRating(d.TimesCrossingLine);
            int signsRanRating = GetSignsRanRating(d.StopSignsRan);
            int trailingRating = GetDriversTrailedRating(d.DriversTrailed);
            int totalRating = (speedRating + timesSpeedingRating + signsRanRating + crossedLineRating + trailingRating);
            return totalRating;
        }
        private decimal GetDriverPremium(Driver d)
        {
            decimal insuranceRate = 200.00m;
            int speedRating = GetSpeedRating(d.AverageSpeed);
            int timesSpeedingRating = GetTimeSpeedingRating(d.TimesOverSpeedLimit);
            int crossedLineRating = LineCrossedRating(d.TimesCrossingLine);
            int signsRanRating = GetSignsRanRating(d.StopSignsRan);
            int trailingRating = GetDriversTrailedRating(d.DriversTrailed);
            int totalRating = (speedRating + timesSpeedingRating + signsRanRating + crossedLineRating + trailingRating);
            if (totalRating >= 23)
            {
                return Math.Round(insuranceRate * .1225m, 2);
            }
            else if (totalRating >= 20)
            {
                return Math.Round(insuranceRate * .2535m, 2);
            }
            else if (totalRating >= 17)
            {
                return Math.Round(insuranceRate * .3250m, 2);
            }
            else if (totalRating >= 13)
            {
                return Math.Round(insuranceRate * .4825m, 2);
            }
            else if (totalRating >= 10)
            {
                return Math.Round(insuranceRate * .5685m, 2);
            }
            else if (totalRating >= 7)
            {
                return Math.Round(insuranceRate * .6825m, 2);
            }
            else if (totalRating >= 4)
            {
                return Math.Round(insuranceRate * .7550m, 2);
            }
            else
            {
                return insuranceRate;
            }
        }
        private int LineCrossedRating(int linesCrossed)
        {
            int linesCrossedRating;
            if (linesCrossed >= 80)
            {
                linesCrossedRating = 0;
                return linesCrossedRating;
            }
            else if (linesCrossed >= 60)
            {
                linesCrossedRating = 1;
                return linesCrossedRating;
            }
            else if (linesCrossed >= 40)
            {
                linesCrossedRating = 2;
                return linesCrossedRating;
            }
            else if (linesCrossed >= 20)
            {
                linesCrossedRating = 4;
                return linesCrossedRating;
            }
            else
            {
                linesCrossedRating = 5;
                return linesCrossedRating;
            }
        }
        private int GetSpeedRating(double speed)
        {
            int speedRating;
            if (speed >= 65.0)
            {
                speedRating = 1;
                return speedRating;
            }
            else if (speed >= 55.0)
            {
                speedRating = 2;
                return speedRating;
            }
            else if (speed >= 45.0)
            {
                speedRating = 4;
                return speedRating;
            }
            else if (speed >= 35.0)
            {
                speedRating = 5;
                return speedRating;
            }
            else
            {
                speedRating = 0;
                return speedRating;
            }
        }
        private int GetTimeSpeedingRating(int timesSpeeding)
        {
            int timeSpeedingRating;
            if (timesSpeeding >= 10)
            {
                timeSpeedingRating = 0;
                return timeSpeedingRating;
            }
            else if (timesSpeeding >= 8)
            {
                timeSpeedingRating = 1;
                return timeSpeedingRating;
            }
            else if (timesSpeeding >= 6)
            {
                timeSpeedingRating = 2;
                return timeSpeedingRating;
            }
            else if (timesSpeeding >= 3)
            {
                timeSpeedingRating = 4;
                return timeSpeedingRating;
            }
            else
            {
                timeSpeedingRating = 5;
                return timeSpeedingRating;
            }


        }
        private int GetSignsRanRating(int signsRan)
        {
            int signsRanRating;
            if (signsRan >= 15)
            {
                signsRanRating = 0;
                return signsRanRating;
            }
            else if (signsRan >= 10)
            {
                signsRanRating = 1;
                return signsRanRating;
            }
            else if (signsRan >= 7)
            {
                signsRanRating = 2;
                return signsRanRating;
            }
            else if (signsRan >= 4)
            {
                signsRanRating = 4;
                return signsRanRating;
            }
            else
            {
                signsRanRating = 5;
                return signsRanRating;
            }
        }
        private int GetDriversTrailedRating(int driversTrailed)
        {
            int trailedRating;
            if (driversTrailed >= 80)
            {
                trailedRating = 0;
                return trailedRating;
            }
            else if (driversTrailed >= 60)
            {
                trailedRating = 1;
                return trailedRating;
            }
            else if (driversTrailed >= 40)
            {
                trailedRating = 2;
                return trailedRating;
            }
            else if (driversTrailed >= 20)
            {
                trailedRating = 4;
                return trailedRating;
            }
            else
            {
                trailedRating = 5;
                return trailedRating;
            }
        }
        private void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
