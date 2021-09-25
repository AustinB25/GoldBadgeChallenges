using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_2_Claims
{
    public class ClaimsRepository
    {
        public Queue<Claims> _claims = new Queue<Claims>();
        int iDCount = default;
        //Create 
        public bool CreateClaim(Claims newClaim)
        {
            if (newClaim == null)
            {
                return false;
            }
            newClaim.ClaimID = ++iDCount;
            _claims.Enqueue(newClaim);
            return true;
        }
        //Read
        public Queue<Claims> SeeAllClaims()
        {
            return _claims;
        }
        //Update
        public bool UpdateAClaim(int id, Claims updatedClaim)
        {
            Claims exsistingClaim = FindClaimById(id);
            if (exsistingClaim == null)
            {
                return false;
            }
            exsistingClaim.ClaimAmount = updatedClaim.ClaimAmount;
            exsistingClaim.ClaimType = updatedClaim.ClaimType;
            exsistingClaim.DateOfClaim = updatedClaim.DateOfClaim;
            exsistingClaim.DateOfIncident = updatedClaim.DateOfIncident;
            exsistingClaim.Description = updatedClaim.Description;
            exsistingClaim.isClaimValid = updatedClaim.isClaimValid;
            return true;
        }
        //Delete 
        public bool DeQueueAClaim(int id)
        {            
            Claims exsistingClaim = FindClaimById(id);
            if (exsistingClaim == null)
            {
                return false;
            }
            _claims.Dequeue();
            return true;

        }
        //Helper Method
        public Claims FindClaimById(int id)
        {
            foreach (Claims claim in _claims)
            {
                if (claim.ClaimID == id)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
