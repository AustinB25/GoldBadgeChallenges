using GoldBadgeChallenge_7_Barbeque;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GoldBadgeChallengesRepositories
{
    [TestClass]
    public class Challenge_7_Company_Barbeques
    {
        BarbequeRepository _bbqRepo = new BarbequeRepository();
        [TestInitialize]
        public void Arrange()
        {
            Barbeque firstBBQ = new Barbeque();
            Barbeque secondBBQ = new Barbeque();
            BarbequeBurgerBooth mrBeastBurger = new BarbequeBurgerBooth();
            BarbequeBurgerBooth fiveGuys = new BarbequeBurgerBooth();
            BarbequeIceCreamBooth jaysIceCream = new BarbequeIceCreamBooth();
            BarbequeIceCreamBooth jaysIceCream2 = new BarbequeIceCreamBooth();
            mrBeastBurger.FoodPrice = 665.23m;
            mrBeastBurger.Name = "Mr. Beast Burger";
            mrBeastBurger.TicketsTaken = 98;
            fiveGuys.FoodPrice = 953.64m;
            fiveGuys.Name = "Five Guys";
            fiveGuys.TicketsTaken = 149;
            jaysIceCream.Name = "Jay's Ice Cream";
            jaysIceCream.SweetsPrice = 412.52m;
            jaysIceCream.TicketsTaken = 98;
            jaysIceCream2.Name = "Jay's Ice Cream";
            jaysIceCream2.SweetsPrice = 578.43m;
            jaysIceCream2.TicketsTaken = 124;
            firstBBQ.BurgerBooth = mrBeastBurger;
            secondBBQ.BurgerBooth = fiveGuys;
            firstBBQ.IceCreamBooth = jaysIceCream;
            secondBBQ.IceCreamBooth = jaysIceCream2;
            _bbqRepo.CreateACompanyBarbeque(firstBBQ);
            _bbqRepo.CreateACompanyBarbeque(secondBBQ);
        }
        [TestMethod]
        public void CreateACompanyBarbeque_BarbequeIsNull_ReturnFalse()
        {
            Barbeque newBbq = null;

            bool result = _bbqRepo.CreateACompanyBarbeque(newBbq);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CreateACompanyBarbeque_BarbequeIsNotNull_ReturnTrue()
        {
            Barbeque newBbq = new Barbeque();

            bool result = _bbqRepo.CreateACompanyBarbeque(newBbq);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FindBbqById_BarbequeDoesNotExsist_ReturnNull()
        {
            int id = 5;

            Barbeque result = _bbqRepo.FindBbqById(id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void FindBbqById_BarbequeDoesExsist_ReturnBarbeque()
        {
            int id = 2;

            Barbeque result = _bbqRepo.FindBbqById(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.ID, id);
        }
    }
}
