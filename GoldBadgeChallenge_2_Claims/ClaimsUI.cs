using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_2_Claims
{
    public class ClaimsUI
    {
        private ClaimsRepository _claimsRepository = new ClaimsRepository();
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
                Console.Clear();
                Console.WriteLine("Welcome to the Claims Managment System\n" +
                    "\n" +
                    "What would you like to do?\n" +
                    "\n" +
                    "1. See All Claims\n" +
                    "2. Take care of the next claim\n" +
                    "3. Enter a new Claim\n" +
                    "4. Leave the System");

                int mainInput = int.Parse(Console.ReadLine());
                switch (mainInput)
                {
                    case 1://1. See All Claims
                        SeeAllClaims();
                        break;
                    case 2://2. Take care of the next claim
                        TakeCareOfNextClaim();
                        break;
                    case 3://3. Enter a new Claim
                        EnterANewClaim();
                        break;
                    case 4://4. Leave the System
                        break;
                    default:
                        break;
                }
            }
        }
        public void SeeAllClaims()
        {
            Console.Clear();
            Console.WriteLine("ClaimID     Type       Description    Amount     DateOfAccident     DateOfClaim    IsValid");
            foreach (Claims claim in _claimsRepository.SeeAllClaims())
            {
                Console.WriteLine($"{claim.ClaimID}     {claim.ClaimType}       {claim.Description}     ${claim.ClaimAmount}        {DateOfIncidentString(claim.ClaimID)}       {DateOfClaimString(claim.ClaimID)}      {claim.IsClaimValid}");
            }
            PressAnyKey();
        }
        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            bool takingCareOfClaims = true;
            do
            {
                Console.Clear();
                Claims nextClaim = _claimsRepository.ViewNextClaimInQueue();
                Console.WriteLine("Here are the details for the next claim to be handled:\n\n"
                   + $"ClaimID: {nextClaim.ClaimID}\n"
                   + $"Type: {nextClaim.ClaimType}\n"
                   + $"Description: {nextClaim.Description}\n"
                   + $"Amount: {nextClaim.ClaimAmount}\n"
                   + $"Date of incident: {DateOfIncidentString(nextClaim.ClaimID)}\n"
                   + $"Date of claim: {DateOfClaimString(nextClaim.ClaimID)}\n"
                   + $"Is the claim valid: {nextClaim.IsClaimValid}\n\n"
                   + "Would you like to take care of this claim now (y/n) ?");
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "y")
                {
                    _claimsRepository.DeQueueAClaim();
                }
                else if (userInput == "n")
                {
                    Console.Clear();
                    Console.WriteLine("Back to the Main Menu you go.");
                    PressAnyKey();
                    takingCareOfClaims = false;
                }
                else
                {
                    takingCareOfClaims = false;
                }
            } while (takingCareOfClaims);
        }
        public void EnterANewClaim()
        {
            Claims newClaim = new Claims();
            Console.WriteLine("What type of claim is this? (Car, Home, Theft)");
            string claimType = Console.ReadLine().ToLower();
            switch (claimType)
            {
                case "car":
                    newClaim.ClaimType = ClaimType.Car;
                    break;
                case "home":
                    newClaim.ClaimType = ClaimType.Home;
                    break;
                case "theft":
                    newClaim.ClaimType = ClaimType.Theft;
                    break;
                default:
                    return;                    
            }
            Console.WriteLine("Please enter a description on the incident.");
            newClaim.Description = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("How much was the claim worth. Please enter as dollars without dollar sign");
            double claimAmount = double.Parse(Console.ReadLine());
            newClaim.ClaimAmount = claimAmount;
            Console.Clear();
            Console.WriteLine("What was the month (1 - 12) that the incident occured in?");
            int incidentMonth = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("What day(1 - 31) on the month did it occur on?");
            int incidentDay = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("What year (ex. 2021) did the incident occur in?");
            int incidentYear = int.Parse(Console.ReadLine());
            Console.Clear(); 
            Console.WriteLine("What was the month (1 - 12) that the claim was filed in?");
            int claimMonth = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("What day(1 - 31) on the month was the claim filed on?");
            int claimDay = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("What year (ex. 2021) was the claim filed in?");
            int claimYear = int.Parse(Console.ReadLine());
            Console.Clear();
            DateTime incidentDate = new DateTime(incidentYear, incidentMonth, incidentDay);
            DateTime claimDate = new DateTime(claimYear, claimMonth, claimDay);
            newClaim.DateOfClaim = claimDate;
            newClaim.DateOfIncident = incidentDate;
            _claimsRepository.CreateClaim(newClaim);
            if (newClaim != null)
            {
                Console.WriteLine("Your claim has been added to the queue.");
            }
            PressAnyKey();
        }
        public string DateOfIncidentString(int id)
        {
            Claims claim = _claimsRepository.FindClaimById(id);
            string dateAsString = $"{claim.DateOfIncident.Month}/{ claim.DateOfIncident.Day}/{ claim.DateOfIncident.Year}";
            return dateAsString;
        }
        public string DateOfClaimString(int id)
        {
            Claims claim = _claimsRepository.FindClaimById(id);
            string dateAsString = $"{claim.DateOfClaim.Month}/{ claim.DateOfClaim.Day}/{ claim.DateOfClaim.Year}";
            return dateAsString;
        }
        public void SeedData()
        {
            Claims seedClaim1 = new Claims(ClaimType.Car, "Car accident on 465.", 400.00, new DateTime(18, 4, 25), new DateTime(18, 4, 27));
            Claims seedClaim2 = new Claims(ClaimType.Home, "House fire in kitchen.", 4000.00, new DateTime(18, 4, 11), new DateTime(18, 4, 12));
            Claims seedClaim3 = new Claims(ClaimType.Theft, "Stolen pancakes.", 4.00, new DateTime(18, 4, 27), new DateTime(18, 6, 01));
            _claimsRepository.CreateClaim(seedClaim3);
            _claimsRepository.CreateClaim(seedClaim2);
            _claimsRepository.CreateClaim(seedClaim1);

        }
        public void PressAnyKey()
        {
            Console.WriteLine("Press any key to conitue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
