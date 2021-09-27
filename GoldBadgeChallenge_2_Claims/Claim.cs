using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_2_Claims
{
    public class Claim
    {
        public Claim(){}
        public Claim(string description, double claimAmount) 
        {
            Description = description;
            ClaimAmount = claimAmount;
        }
        public Claim(ClaimType claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {            
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;            
        }

       public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public TimeSpan AgeOfClaim { get { return (DateOfClaim - DateOfIncident); } }
        public bool IsClaimValid { get { if (AgeOfClaim.Days <= 30) { return true; } return false; } } //if the claim date is less than 30 days after the incident it is valid if(DateOfClaim - DateOfIncident <= 30days)    
    }
    public enum ClaimType
    {
        Car,
        Home,
        Theft
    }
}
