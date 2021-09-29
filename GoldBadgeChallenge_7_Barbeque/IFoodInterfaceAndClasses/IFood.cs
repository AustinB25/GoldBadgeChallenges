using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_7_Barbeque.IFoodInterfaceAndClasses
{
    public interface IFood
    {
        string Name { get;  }
        decimal Price { get; }
        decimal Protien { get; }
        decimal Bun { get;  }
        decimal Ketchup { get; }
        decimal Mustard { get; }
        decimal PlasticWare { get; }
        decimal Cheese { get;  }
        decimal Napkins { get;}
        decimal AddOnTotal { get;  }
    }
}
