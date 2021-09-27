using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;


namespace GoldBadgeChallenge_4_Company_Outings
{
    public class CompanyOutingsUI
    {
        private CompanyOutingsRepository _companyOutingsRepository = new CompanyOutingsRepository();
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
                Console.WriteLine("You are in the Company Outings Menu.\n"
                                  + "\n"
                                  + "What would you like to do?\n"
                                  + "\n"
                                  + "1. View all of the company outings\n"
                                  + "2. Add a new company outing\n"
                                  + "3. See break down of outing costs\n"
                                  + "4. Exit the program");
                int menuInput = int.Parse(Console.ReadLine());
                switch (menuInput)
                {
                    case 1:
                        ViewAllCompanyOutings();
                        break;
                    case 2:
                        CreateNewOutingUI();
                        break;
                    case 3:
                        ViewCostBreakDown();
                        break;
                    case 4:
                        Console.WriteLine("Goodbye!");
                        System.Threading.Thread.Sleep(2000);
                        isRunning = false;
                        break;
                    default:
                        IntSwitchDefault();
                        break;
                }
            }
        }
        public void CreateNewOutingUI()
        {
            Console.Clear();
            CompanyOuting newOuting = new CompanyOuting();
            Console.WriteLine("What type of outting was it?\n"
                + "1. Golf\n"
                + "2. Concert\n"
                + "3. Amusement Park\n"
                + "4. Bowling\n");
            int eventType = int.Parse(Console.ReadLine());
            switch (eventType)
            {
                case 1:
                    newOuting.EventType = EventType.Golf;
                    break;
                case 2:
                    newOuting.EventType = EventType.Concert;
                    break;
                case 3:
                    newOuting.EventType = EventType.Amusement_Park;
                    break;
                case 4:
                    newOuting.EventType = EventType.Bowling;
                    break;
                default:
                    IntSwitchDefault();
                    break;
            }
            Console.Clear();
            Console.WriteLine("How many employees went to the event?");
            newOuting.PeopleInAttendance = int.Parse(Console.ReadLine());
            Console.WriteLine("What did it cost per person for the event? (ex. 15.32) ");
            newOuting.CostPerPerson = decimal.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("What month (1 - 12) was the event in?");
            int eventMonth = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("What day (1 - 31) was the event on?");
            int eventDay = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("What year (ex. 2021) was the event in?");
            int eventYear = int.Parse(Console.ReadLine());
            Console.Clear();
            newOuting.DateOfAttendance = new DateTime(eventYear, eventMonth, eventDay);
            bool resultCreated = _companyOutingsRepository.CreateNewOuting(newOuting);
            if (resultCreated == true)
            {
                Console.WriteLine("The event has been created!");
                PressAnyKey();
            }
            else
            {
                Console.WriteLine("The event was not created.");
                PressAnyKey();
            }
        }
        public void ViewAllCompanyOutings()
        {
            Console.Clear();
            foreach (CompanyOuting outing in _companyOutingsRepository.SeeAllOutings())
            {
                Console.WriteLine($"Outing ID: {outing.OutingID}   Outing type: {outing.EventType}\n"
                    + $"Date of outing: {DateTimeAsString(outing.OutingID)} \n"
                    + $"Employees in attendance: {outing.PeopleInAttendance}\n"
                    + $"Total cost of outing: ${outing.CostOfEvent}\n");
            }
            PressAnyKey();
        }
        public void ViewCostBreakDown()
        {
            Console.Clear();
            Console.WriteLine("What would you like to view?\n"
                + "\n"
                + "1. Total cost of events by category\n"
                + "2.Total cost of all logged events");
            int costInput = int.Parse(Console.ReadLine());
            switch (costInput)
            {
                case 1:
                    CostPerEventType();
                    break;
                case 2:
                    Console.WriteLine($"${TotalCostsOfAllEvents()}");
                    PressAnyKey();
                    break;
                default:
                    IntSwitchDefault();
                    break;
            }
        }
        public void CostPerEventType()
        {
            Console.Clear();
            //set initail value for each event            
            decimal bowlingTotal = default;
            decimal concertTotal = default;
            decimal amusementParkTotal = default;
            decimal golfTotal = default;
            //find event type
            foreach (CompanyOuting outings in _companyOutingsRepository.SeeAllOutings())
            {
            //add event type costs
                if (outings.EventType == EventType.Golf)
                {
                    golfTotal += outings.CostOfEvent;
                }
                else if (outings.EventType == EventType.Bowling)
                {
                    bowlingTotal += outings.CostOfEvent;
                }
                else if (outings.EventType == EventType.Amusement_Park)
                {
                    amusementParkTotal += outings.CostOfEvent;
                }
                else if (outings.EventType == EventType.Concert)
                {
                    concertTotal += outings.CostOfEvent;
                }
            }
            Console.WriteLine("Total cost per event:\n\n"
                + $"Golfing: ${golfTotal}\n"
                + $"Bowling: ${bowlingTotal}\n"
                + $"Amusement Parks: ${amusementParkTotal}\n"              
                + $"Concerts: ${concertTotal}");
            PressAnyKey();
        }
        public decimal TotalCostsOfAllEvents()
        {
            Console.Clear();
            //set initial value to zero
            decimal total = default;
            //add the next value in list to initial value
            foreach (CompanyOuting outing in _companyOutingsRepository.SeeAllOutings())
            {
                total += outing.CostOfEvent;
            }
            //return the total value of the events
            return total;
        }
        public void SeedData()
        {
            CompanyOuting seed1 = new CompanyOuting(24, new DateTime(2021, 8, 23), 10.78m, EventType.Bowling);
            CompanyOuting seed2 = new CompanyOuting(39, new DateTime(2020, 11, 21), 20.00m, EventType.Concert);
            CompanyOuting seed3 = new CompanyOuting(47, new DateTime(2021, 6, 15), 15.75m, EventType.Amusement_Park);
            _companyOutingsRepository.CreateNewOuting(seed1);
            _companyOutingsRepository.CreateNewOuting(seed2);
            _companyOutingsRepository.CreateNewOuting(seed3);
        }
        public string DateTimeAsString(int id)
        {
            CompanyOuting outing = _companyOutingsRepository.FindOutingByID(id);
            string dateAsString = $"{outing.DateOfAttendance.Month}/{ outing.DateOfAttendance.Day}/{ outing.DateOfAttendance.Year}";
            return dateAsString;
        }
        public void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        public void IntSwitchDefault()
        {
            Console.WriteLine("You did not enter a valid number...");
            PressAnyKey();
        }
        
    }
}
