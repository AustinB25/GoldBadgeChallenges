using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_7_Barbeque.ISweetsInterfaceAndClasses
{
    public interface ISweets
    {
        decimal Price { get;  }
        string Name { get;  }
        decimal Napkins  { get;  }
        decimal Spoons { get;  }
        decimal Bowl { get;  }
    }
}
