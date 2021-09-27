using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_2_Claims
{
    public class ClaimsRepository
    {
        private Queue<Claim> _claims = new Queue<Claim>();
        int iDCount = default;
        //Create 
        public bool CreateClaim(Claim newClaim)
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
        public Queue<Claim> SeeAllClaims()
        {
            return _claims;
        }          
        //Delete 
        public void  DeQueueAClaim()
        {  
            _claims.Dequeue(); 
        }
        //Helper Method
       public Claim ViewNextClaimInQueue()
        {
            return _claims.Peek();
        }
        public Claim FindClaimById(int id)
        {
            foreach (Claim claim in _claims)
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
