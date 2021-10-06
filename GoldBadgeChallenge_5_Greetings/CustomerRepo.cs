using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_5_Greetings
{
    public class CustomerRepo
    {
        private List<Customer> _customers = new List<Customer>();
        int iDCount = default;
        public bool CreateANewCustomer(Customer cust)
        {
            if(cust == null)
            {
                return false;
            }
            cust.CustomerID = ++iDCount;
            _customers.Add(cust);
            return true;
        }
        public List<Customer> SeeAllCustomers()
        {
            return _customers;
        }
        public Customer FindCustomerById(int id)
        {
            foreach(Customer cust in _customers)
            {
                if (cust.CustomerID == id)
                {
                    return cust;
                }
            }
            return null;
        }
        public bool UpdateACustomer(int id, Customer newCust)
        {
            Customer oldCust = FindCustomerById(id);
            if (oldCust == null)
            {
                return false;
            }

            oldCust.CustomerType = newCust.CustomerType;
            oldCust.Email = newCust.Email;
            oldCust.FirstName = newCust.FirstName;
            oldCust.LastName = newCust.LastName;
            return true;
        }
        public bool DeleteACustomer(int id)
        {
            Customer deleteCust = FindCustomerById(id);
            if (deleteCust == null)
            {
                return false;
            }
            _customers.Remove(deleteCust);
            return true;
        }
    }
}
