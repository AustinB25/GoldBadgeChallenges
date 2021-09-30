using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_7_Barbeque
{
    public class Barbeque
    {
        public  int ID { get; set; }
        public DateTime DayOfEvent { get; set; }
        public BarbequeBurgerBooth BurgerBooth { get; set; }
        public BarbequeIceCreamBooth IceCreamBooth { get; set; }        
    }
}
