using GoldBadgeChallenge_5_Greetings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GoldBadgeChallengesRepositories
{
    [TestClass]
    public class Challenge_5_Geetings_UnitTests
    {
        private CustomerRepo _custRepo = new CustomerRepo();
        [TestInitialize]
        public void Arrange()
        {
            Customer testCust = new Customer("Austin", "Bridgewater", CustomerType.Current, "ab@gmail.com");
            _custRepo.CreateANewCustomer(testCust);
        }
        [TestMethod]
        public void CreateANewCustomer_CustomerIsNull_ReturnFalse()
        {
            Customer testCust = null;
            bool result = _custRepo.CreateANewCustomer(testCust);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CreateANewCustomer_CustomerIsNotNull_ReturnTrue()
        {
            Customer testCust = new Customer();
            bool result = _custRepo.CreateANewCustomer(testCust);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FindCustomerById_CustomerDoesNotExsist_ReturnNull()
        {
            int id = 5;
            Customer result = _custRepo.FindCustomerById(id);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void FindCustomerById_CustomerDeosExsist_ReturnCustomer()
        {
            int id = 1;
            Customer result = _custRepo.FindCustomerById(id);
            Assert.AreEqual(result.CustomerID, id);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void UpdateACustomer_CustomerDoesNotExsist_ReturnFalse()
        {
            int id = 5;
            Customer updateCust = new Customer();
            updateCust.FirstName = "Katelyn";
            bool result = _custRepo.UpdateACustomer(id, updateCust);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void UpdateACustomer_CustomerDoesExsist_ReturnTrue()
        {
            int id = 1;
            Customer updateCust = new Customer();
            updateCust.FirstName = "Katelyn";
            bool result = _custRepo.UpdateACustomer(id, updateCust);
            Assert.IsTrue(result);           
        }
        [TestMethod]
        public void UpdateACustomer_CustomerDoesExsist_PropertyCheck()
        {
            int id = 1;
            Customer updateCust = new Customer();
            updateCust.FirstName = "Katelyn";
            updateCust.CustomerType = CustomerType.Past;
            bool result = _custRepo.UpdateACustomer(id, updateCust);
            Assert.AreEqual(updateCust.FirstName, "Katelyn");
            Assert.AreEqual(updateCust.CustomerType, CustomerType.Past);
        }
        [TestMethod]
        public void DeleteACustomer_CustomerDoesNotExsist_ReturnFalse()
        {
            int id = 5;
            bool result = _custRepo.DeleteACustomer(id);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void DeleteACustomer_CustomerDoesExsist_ReturnTrue()
        {
            int id = 1;
            bool result = _custRepo.DeleteACustomer(id);
            Assert.IsTrue(result);
        }
    }
}
