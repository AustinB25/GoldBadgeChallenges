using GoldBadgeChallenge_1_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GoldBadgeChallengesRepositories
{
    [TestClass]
    public class Challenge_1_Cafe_RepoTests
    {
        CafeMenuItemRepo _menuItemRepo = new CafeMenuItemRepo();
        [TestInitialize]
        public void Arrange()
        {
            CafeMenuItem hamburger = new CafeMenuItem();
            _menuItemRepo.CreateAMenuItem(hamburger);
        }
        [TestMethod]
        public void CreateAMenuItem_MenuItemIsNull_ReturnFalse()         
        {
            CafeMenuItem newItem = null;

            bool result = _menuItemRepo.CreateAMenuItem(newItem);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CreateAMenuItem_MenuItemIsNotNull_ReturnTrue()
        {
            CafeMenuItem newItem = new CafeMenuItem();

            bool result = _menuItemRepo.CreateAMenuItem(newItem);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FindItemById_ItemDoesExsist_ReturnItem()
        {
            int id = 1;

            CafeMenuItem result = _menuItemRepo.FindItemByID(id);

            Assert.AreEqual(result.ID, id);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void FindItemById_ItemDoesNotExsist_ReturnNull()
        {
            int id = 5;

            CafeMenuItem result = _menuItemRepo.FindItemByID(id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void RemoveAMenuItem_ItemDoesNotExsist_ReturnFalse()
        {
            int id = 5;

            bool result = _menuItemRepo.RemoveAMenuItem(id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void RemoveAMenuItem_ItemDoesExsist_ReturnTrue()
        {
            int id = 1;

            bool result = _menuItemRepo.RemoveAMenuItem(id);

            Assert.IsTrue(result);
        }
    }
}
