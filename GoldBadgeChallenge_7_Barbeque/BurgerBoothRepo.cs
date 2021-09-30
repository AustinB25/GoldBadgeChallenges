using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_7_Barbeque
{
    public class BurgerBoothRepo
    {
        private List<BarbequeBurgerBooth> _burgerBooths = new List<BarbequeBurgerBooth>();
        int IDCount = default;
        public bool CreateABurgerBooth(BarbequeBurgerBooth newBooth)
        {
            if (newBooth == null)
            {
                return false;
            }
            newBooth.ID = ++IDCount;
            _burgerBooths.Add(newBooth);
            return true;
        }
        public List<BarbequeBurgerBooth> SeeAllBurgerBooths()
        {
            return _burgerBooths;
        }
        public BarbequeBurgerBooth FindBurgerBoothById(int id)
        {
            foreach (BarbequeBurgerBooth burgerBooth in _burgerBooths)
            {
                if (burgerBooth.ID == id)
                {
                    return burgerBooth;
                }
            }
            return null;
        }
    }
}
