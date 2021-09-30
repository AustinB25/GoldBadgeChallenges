using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_7_Barbeque.IFoodInterfaceAndClasses
{
    public class HotDog : IFood
    {
        public HotDog() {}
        public string Name { get { return "Hot Dog "; } }
        public decimal Price { get { return Protien + Bun + AddOnTotal; } }
        public decimal Protien { get { return 1.00m; } }
        public decimal Bun { get { return 0.25m; } }
        public decimal Ketchup { get { return 0.05m; } }
        public decimal Mustard { get { return 0.05m; } }
        public decimal PlasticWare { get { return 0.10m; } }
        public decimal Cheese { get { return 0.75m; } }
        public decimal Napkins { get { return 0.05m; } }
        public decimal AddOnTotal { get { return Ketchup + Mustard + PlasticWare + Cheese + Napkins; } }
    }
}
