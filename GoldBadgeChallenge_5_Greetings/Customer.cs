using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_5_Greetings
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(string firstName, string lastName, CustomerType customerType, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerType = customerType;
            Email = email;
        }

        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public CustomerType CustomerType { get; set; }
        public string Email { get; set; }
    }
    public enum CustomerType
    {
        Current,
        Past,
        Potential
    }
}
