using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_7_Barbeque
{
    public class IceCreamBoothRepo
    {
        private List<BarbequeIceCreamBooth> _iceCreamBooths = new List<BarbequeIceCreamBooth>();
        int IDCount = default;
        public bool CreateAnIceCreamBooth(BarbequeIceCreamBooth newBooth)
        {
            if (newBooth == null)
            {
                return false;
            }
            newBooth.ID = ++IDCount;
            _iceCreamBooths.Add(newBooth);
            return true;
        }
        public List<BarbequeIceCreamBooth> SeeAllIceCreamBooths()
        {
            return _iceCreamBooths;
        }
        public BarbequeIceCreamBooth FindIceCreamBoothById(int id)
        {
            foreach (BarbequeIceCreamBooth booth in _iceCreamBooths)
            {
                if (booth.ID == id)
                {
                    return booth;
                }
            }
            return null;
        }
    }
}
