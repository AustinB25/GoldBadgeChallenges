using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_7_Barbeque.ISweetsInterfaceAndClasses
{
    public class IceCream : ISweets
    {
        public string Name { get { return "Ice Cream"; } }
        public decimal Price {get {return 1.25m;} }
        public decimal Napkins { get { return 0.25m; } }
        public decimal Spoons { get { return 0.05m; } }
        public decimal Bowl { get { return 0.10m; } }
    }
}
