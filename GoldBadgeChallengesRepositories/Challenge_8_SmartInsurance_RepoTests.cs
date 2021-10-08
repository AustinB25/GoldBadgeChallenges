using GoldBadgeChallenges_8_SmartInsurance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GoldBadgeChallengesRepositories
{
    [TestClass]
    public class Challenge_8_SmartInsurance_RepoTests
    {
        private DriverRepository _driverRepo = new DriverRepository();
        [TestInitialize]
        public void Arrange()
        {
            Driver arrange1 = new Driver();
            _driverRepo.CreateANewDriver(arrange1);
        }
        [TestMethod]
        public void CreateANewDriver_DriverIsNull_ReturnFalse()
        {
            Driver testD = null;
            bool result = _driverRepo.CreateANewDriver(testD);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CreateANewDriver_DriverIsNotNull_ReturnTrue()
        {
            Driver testD = new Driver();
            bool result = _driverRepo.CreateANewDriver(testD);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FindASpecificDriver_DriverDoesNotExsist_ReturnNull()
        {
            int id = 55;
            Driver result = _driverRepo.FindASpecififcDriver(id);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void FindASpecificDriver_DriverDoesExsist_ReturnDriver()
        {
            int id = 1;
            Driver result = _driverRepo.FindASpecififcDriver(id);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.DriverID, id);
        }
        [TestMethod]
        public void UpdateADriver_DriverDoesNotExsist_ReturnFalse()
        {
            int id = 5;
            bool result = _driverRepo.UpdateADriver(id);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void UpdateADriver_DriverDoesExsist_ReturnTrue()
        {
            int id = 1;
            bool result = _driverRepo.UpdateADriver(id);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdateADriver_DriverDoesExsist_PropertyCheck()
        {
            int id = 1;
            Driver testD = new Driver();
            testD.FirstName = "Austin";
            bool result = _driverRepo.UpdateADriver(id);
            Assert.IsTrue(result);
            Assert.AreEqual(testD.FirstName, "Austin");
        }
        [TestMethod]
        public void DeleteADriver_DriverDoesNotExsist_ReturnFalse()
        {
            int id = 5;
            bool result = _driverRepo.RemoveADriver(id);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void DeleteADriver_DriverDoesExsist_ReturnTrue()
        {
            int id = 1;
            bool result = _driverRepo.RemoveADriver(id);
            Assert.IsTrue(result);
        }
    }
}
