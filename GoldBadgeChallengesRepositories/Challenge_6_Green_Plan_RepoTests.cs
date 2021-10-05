using GoldBadgeChallenge_6_Green_Plan;
using GoldBadgeChallenge_6_Green_Plan.CarInterFaceAndClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GoldBadgeChallengesRepositories
{
    [TestClass]
    public class Challenge_6_Green_Plan_RepoTests        
    {
        private CarRepository _carRepo = new CarRepository();
        [TestInitialize]
        public void Arrange()
        {
            Car arrangeCar = new Car(2021, "Dodge", "Charger", 203, FeulType.Gas);
            _carRepo.CreateACar(arrangeCar);

        }
        [TestMethod]
        public void CreateACar_CarIsNull_ReturnFalse()
        {
            Car newCar = null;

            bool result = _carRepo.CreateACar(newCar);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CreateACar_CarIsNotNull_ReturnTrue ()
        {
            Car newCar = new Car();

            bool result = _carRepo.CreateACar(newCar);

            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FindCarById_CarDoesExsist_ReturnCar()
        {
            int id = 1;

            Car result = _carRepo.FindCarById(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.ID, id);
        }
        [TestMethod]
        public void FindCarById_CarDoesNotExsist_ReturnNull()
        {
            int id = 5;

            Car result = _carRepo.FindCarById(id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void UpdateACar_CarDoesExsist_ReturnTrue()
        {
            int id = 1;
            Car newCar = new Car();
            newCar.Model = "Chevy";

            bool result = _carRepo.UpdateACar(id, newCar);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdateACar_CarDoesNotExsist_ReturnFalse()
        {
            int id = 6;
            Car newCar = new Car();
            newCar.Model = "Chevy";

            bool result = _carRepo.UpdateACar(id, newCar);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void UpdateACar_CarDoesExsist_PropertyCheck()
        {
            int id = 1;
            Car newCar = new Car(2006, "Ford", "F-150",190000, FeulType.Gas);
            

            bool result = _carRepo.UpdateACar(id, newCar);

            Assert.IsTrue(result);
            Assert.AreEqual("Ford", newCar.Make);
        }
        [TestMethod]
        public void DeleteACar_CarDoesExsist_ReturnTrue()
        {
            int id = 1;

            bool result = _carRepo.DeleteACar(id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void DeleteACar_CarDoesNotExsist_ReturnFalse()
        {
            int id = 6;

            bool result = _carRepo.DeleteACar(id);

            Assert.IsFalse(result);
        }
    }
}
