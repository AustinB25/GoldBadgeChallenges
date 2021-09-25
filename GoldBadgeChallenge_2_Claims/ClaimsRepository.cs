using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_2_Claims
{
    public class ClaimsRepository
    {
        private Queue<Claims> _claims = new Queue<Claims>();
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
     
        //Delete 
        public void  DeQueueAClaim()
        {  
            _claims.Dequeue(); 
        }
        //Helper Method
       public Claims ViewNextClaimInQueue()
        {
            return _claims.Peek();
        }
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
