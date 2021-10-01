using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_1_Cafe
{
    public class CafeMenuItem
    {
        public CafeMenuItem() { }

        public CafeMenuItem(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }
    }   
}
