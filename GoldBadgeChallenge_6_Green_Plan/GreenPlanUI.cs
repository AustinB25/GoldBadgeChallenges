using GoldBadgeChallenge_6_Green_Plan.CarInterFaceAndClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_6_Green_Plan
{
    public class GreenPlanUI
    {
        CarRepository _carRepo = new CarRepository();
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
                Console.WriteLine("Welcome to the Green Plan Car Data System\n\n"
                    + "What would you like to do?\n"
                    + "1. Create a new car\n"
                    + "2. See all cars\n"
                    + "3. See cars of a specific type\n"
                    + "4. Update a car\n"
                    + "5. Delete a car\n"
                    + "6. Exit the program");
                int mainInput = int.Parse(Console.ReadLine());
                switch (mainInput)
                {
                    case 1:
                        CreateACarUI();
                        PressAnyKey();
                        break;
                    case 2:
                        SeeAllCars();
                        PressAnyKey();
                        break;
                    case 3:
                        SeeCarsByFuelType();
                        PressAnyKey();
                        break;
                    case 4:
                        UpdateACarUI();
                        PressAnyKey();
                        break;
                    case 5:
                        DeleteACarUI();
                        PressAnyKey();
                        break;
                    case 6:
                        Console.WriteLine("GoodBye!");
                        System.Threading.Thread.Sleep(1500);
                        isRunning = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
            }
        }
        private void CreateACarUI()
        {
            Car newCar = new Car();
            Console.Clear();
            Console.WriteLine("What year was the car manufactured?");
            newCar.Year = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the make of the car?");
            newCar.Make = Console.ReadLine();
            Console.WriteLine("What is the model of the car?");
            newCar.Model = Console.ReadLine();
            Console.WriteLine("How many miles are on the car?");
            newCar.Mileage = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("What is the fuel used for the car? (electric = E, gas = G, hybrid = H)");
            string feulType = Console.ReadLine().ToUpper();
            if (feulType == "E")
            {
                newCar.FeulType = FeulType.Electric;
                _carRepo.CreateACar(newCar);
            }
            if (feulType == "H")
            {
                newCar.FeulType = FeulType.Hybrid;
                _carRepo.CreateACar(newCar);
            }
            if (feulType == "G")
            {
                newCar.FeulType = FeulType.Gas;
                _carRepo.CreateACar(newCar);
            }
            
        }
        private void SeeAllCars()
        {
            Console.Clear();
            foreach (Car car in _carRepo.ViewAllCars())
            {
                Console.WriteLine($"Car ID: {car.ID}    Year: {car.Year}    Make: {car.Make}    Model: {car.Model}      Feul Type: {car.FeulType}\n");
            }            
        }
        private void SeeCarsByFuelType()
        {
            Console.Clear();
            Console.WriteLine("What feul type are you looking for? (1 = Electric, 2 = Hybrid, 3 = Gas)");
            int fuelType = int.Parse(Console.ReadLine());
            if (fuelType == 1)
            {
                foreach (Car car in _carRepo.ViewAllCars())
                {
                    if(car.FeulType == FeulType.Electric)
                    {
                        Console.WriteLine($"Car ID: {car.ID}    Year: {car.Year}    Make: {car.Make}    Model: {car.Model}\n");
                    }
                }
            }
            if (fuelType == 2)
            {
                foreach (Car car in _carRepo.ViewAllCars())
                {
                    if (car.FeulType == FeulType.Hybrid)
                    {
                        Console.WriteLine($"Car ID: {car.ID}    Year: {car.Year}    Make: {car.Make}    Model: {car.Model}\n");
                    }
                }
            }
            if (fuelType == 3)
            {
                foreach (Car car in _carRepo.ViewAllCars())
                {
                    if (car.FeulType == FeulType.Gas)
                    {
                        Console.WriteLine($"Car ID: {car.ID}    Year: {car.Year}    Make: {car.Make}    Model: {car.Model}\n");
                    }
                }
            }            
        }
        private void UpdateACarUI()
        {
            SeeAllCars();
            Console.WriteLine("Please enter the ID of the car you want to update.");
            int id = int.Parse(Console.ReadLine());
            Car updatedCar = new Car();
            Console.Clear();
            Console.WriteLine("What year was the car manufactured?");
            updatedCar.Year = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the make of the car?");
            updatedCar.Make = Console.ReadLine();
            Console.WriteLine("What is the model of the car?");
            updatedCar.Model = Console.ReadLine();
            Console.WriteLine("How many miles are on the car?");
            updatedCar.Mileage = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("What is the fuel used for the car? (electric = E, gas = G, hybrid = H)");
            string feulType = Console.ReadLine().ToUpper();
            if (feulType == "E")
            {
                updatedCar.FeulType = FeulType.Electric;                
            }
            if (feulType == "H")
            {
                updatedCar.FeulType = FeulType.Hybrid;                
            }
            if (feulType == "G")
            {
                updatedCar.FeulType = FeulType.Gas;                
            }
            bool updateCheck = _carRepo.UpdateACar(id, updatedCar);
            Console.Clear();
            if(updateCheck == true)
            {
                Console.WriteLine("The car has been updated.");                
            }
            if(updateCheck == false)
            {
                Console.WriteLine("The car could not be updated.");                
            }
        }
        private void DeleteACarUI()
        {
            Console.Clear();
            SeeAllCars();
            Console.WriteLine("Press enter the ID of the car you want to delete.");
            int id = int.Parse(Console.ReadLine());
            bool deleteCheck = _carRepo.DeleteACar(id);
            if (deleteCheck == true)
            {
                Console.WriteLine("That car was deleted.");
            }
            if(deleteCheck == false)
            {
                Console.WriteLine("That car was not deleted.");
            }
        }
        private void SeedData()
        {
            Car seed1 = new Car(2021, "Dodge", "Charger", 552, FeulType.Gas);
            Car seed2 = new Car(2020, "Chevy", " Malibu", 25612, FeulType.Hybrid);
            Car seed3 = new Car(2018, "Tesla", "Model X", 164821, FeulType.Electric);
            _carRepo.CreateACar(seed1);
            _carRepo.CreateACar(seed2);
            _carRepo.CreateACar(seed3);
        }
        public void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
