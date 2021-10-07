using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_5_Greetings
{
    public class GreetingsUI
    {
        private CustomerRepo _custRepo = new CustomerRepo();
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
                Console.WriteLine($"Welcome to the Komodo Email system\n\n"
                + $"What would you like to do?\n"
                + $"1. Create a new customer\n"
                + $"2. See all customers\n"
                + $"3. See customers alphabetically\n"
                + $"4. Find a specific customer\n"
                + $"5. Update a customer\n"
                + $"6. Remove a customer\n"
                + $"7. Exit the program");
                int mainInput = int.Parse(Console.ReadLine());
                switch (mainInput)
                {
                    case 1:
                        CreateACustomerUI();
                        PressAnyKey();
                        break;
                    case 2:
                        SeeAllCustomers();
                        PressAnyKey();
                        break;
                    case 3:
                        SeeAllCustomersAlphabetically();
                        PressAnyKey();
                        break;
                    case 4:
                        FindSpecificCustomer();
                        PressAnyKey();
                        break;
                    case 5:
                        UpdateACustomer();
                        PressAnyKey();
                        break;
                    case 6:
                        DeleteACustomer();
                        PressAnyKey();
                        break;
                    case 7:
                        Console.WriteLine("Goodbye!");
                        System.Threading.Thread.Sleep(2000);
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        PressAnyKey();
                        break;
                }
            }
        }
        public void CreateACustomerUI()
        {
            Customer newCust = new Customer();
            Console.Clear();
            Console.WriteLine("What is the customers first name?");
            newCust.FirstName = Console.ReadLine();
            Console.WriteLine("What is the customers last name?");
            newCust.LastName = Console.ReadLine();            
            Console.WriteLine("What is the status of the customer? (Current, past, or potential)");
            string custStatus = Console.ReadLine().ToLower();
            if (custStatus == "current")
            {
                newCust.CustomerType = CustomerType.Current;
                newCust.Email = "Thank you for your work with us. We appreciate your loyality. Here's a coupon!";
                _custRepo.CreateANewCustomer(newCust);
            }
            if (custStatus == "past")
            {
                newCust.CustomerType = CustomerType.Past;
                newCust.Email = "It's been a long time since we've heard from you. We want you back.";
                _custRepo.CreateANewCustomer(newCust);
            }
            if (custStatus == "potential")
            {
                newCust.CustomerType = CustomerType.Potential;
                newCust.Email = "We currently have ther lowest rates on helicopter insurance!";
                _custRepo.CreateANewCustomer(newCust);
            }
        }
        public void SeeAllCustomers()
        {
            Console.Clear();
            List<Customer> customers = _custRepo.SeeAllCustomers();
            Console.WriteLine("ID    First name           Last Name           Customer Type           Email");
            foreach (Customer cust in customers)
            {
                Console.WriteLine($"{cust.CustomerID}    {cust.FirstName}            {cust.LastName}             {cust.CustomerType}             {cust.Email}");
            }
        }
        public void SeeAllCustomersAlphabetically()
        {
            Console.Clear();
            List<Customer> customers = _custRepo.SeeAllCustomers();
            customers.Sort(delegate(Customer currentCust, Customer nextCust)
            {

                if (currentCust.FirstName == null && nextCust.FirstName == null) return 0;
                else if (currentCust.FirstName == null) return -1;
                else if (nextCust.FirstName == null) return 1;
                else return currentCust.FirstName.CompareTo(nextCust.FirstName);
            });
            Console.WriteLine("First name           Last Name           Customer Type           Email");
            foreach(Customer cust in customers)
            {
                Console.WriteLine($"{cust.FirstName}            {cust.LastName}             {cust.CustomerType}             {cust.Email}");
            }
        }
        public void FindSpecificCustomer()
        {
            Console.Clear();
            SeeAllCustomers();
            Console.WriteLine("Please enter the id of the customer you want to view");
            int custId = int.Parse(Console.ReadLine());
            Console.Clear();
            Customer foundCust = _custRepo.FindCustomerById(custId);
            Console.WriteLine($"{foundCust.CustomerID}    {foundCust.FirstName}            {foundCust.LastName}             {foundCust.CustomerType}             {foundCust.Email}");
        }
        public void UpdateACustomer()
        {
            Console.Clear();
            SeeAllCustomers();
            Console.WriteLine("Please enter the id of the customer you want to update.");
            int oldCustId = int.Parse(Console.ReadLine());            
            Customer newCust = new Customer();
            Console.Clear();
            Console.WriteLine("What is the customers first name?");
            newCust.FirstName = Console.ReadLine();
            Console.WriteLine("What is the customers last name?");
            newCust.LastName = Console.ReadLine();
            Console.WriteLine("What is the status of the customer? (Current, past, or potential)");
            string custStatus = Console.ReadLine().ToLower();
            if (custStatus == "current")
            {
                newCust.CustomerType = CustomerType.Current;
                newCust.Email = "Thank you for your work with us. We appreciate your loyality. Here's a coupon!";               
            }
            if (custStatus == "past")
            {
                newCust.CustomerType = CustomerType.Past;
                newCust.Email = "It's been a long time since we've heard from you. We want you back.";                
            }
            if (custStatus == "potential")
            {
                newCust.CustomerType = CustomerType.Potential;
                newCust.Email = "We currently have ther lowest rates on helicopter insurance!";                
            }
           bool updated =  _custRepo.UpdateACustomer(oldCustId, newCust);
            if(updated == true)
            {
                Console.WriteLine("Customer was updated");
            }
            if (updated == false)
            {
                Console.WriteLine("Customer was not updated.");
            }
        }
        public void DeleteACustomer()
        {
            Console.Clear();
            SeeAllCustomers();
            Console.WriteLine("\nPlease enter the id of the customer that you want to update.");
            int deleteMe = int.Parse(Console.ReadLine());
            bool wasDeleted = _custRepo.DeleteACustomer(deleteMe);
            if (wasDeleted == true)
            {
                Console.WriteLine("The customer was deleted");
            }
            if (wasDeleted == false)
            {
                Console.WriteLine("The customer was not deleted");
            }
        }
        public void SeedData()
        {
            Customer newCust1 = new Customer("Austin", "Bridgewater", CustomerType.Current, "ab@gmail.com");
            Customer newCust2 = new Customer("Katelyn", "Bridgewater", CustomerType.Past, "kb@gmail.com");
            Customer newCust3 = new Customer("Jeremy", "Aldridge", CustomerType.Potential, "ja@gmail.com");
            _custRepo.CreateANewCustomer(newCust1);
            _custRepo.CreateANewCustomer(newCust2);
            _custRepo.CreateANewCustomer(newCust3);
        }
        public void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();


















































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































            Console.Clear();
        }      
    }
}
