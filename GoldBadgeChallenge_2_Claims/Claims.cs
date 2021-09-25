using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_2_Claims
{
    public class Claims
    {
        public Claims(){}
        public Claims(string description, double claimAmount) 
        {
            Description = description;
            ClaimAmount = claimAmount;
        }
        public Claims(int claimID, ClaimType claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isClaimValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            this.isClaimValid = isClaimValid;
        }

       public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool isClaimValid { get; set; } //if the claim date is less than 30 days after the incident it is valid if(DateOfClaim - DateOfIncident <= 30days)    
    }
    public enum ClaimType
    {
        Car,
        Home,
        Theft
    }
}
