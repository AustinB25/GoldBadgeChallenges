using GoldBadgeChallenge_7_Barbeque.IFoodInterfaceAndClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_7_Barbeque
{
    public class BarbequeBurgerBooth
    {
        public BarbequeBurgerBooth() { }

        public int ID { get; set; }
        public string Name { get; set; }
        public int TicketsTaken { get; set; }
        public decimal FoodPrice  { get; set; }
        
    }
    
}
