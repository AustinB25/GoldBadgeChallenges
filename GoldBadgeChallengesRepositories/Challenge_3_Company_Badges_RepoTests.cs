using GoldBadgeChallenge_3_Company_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GoldBadgeChallengesRepositories
{
    [TestClass]
    public class Challenge_3_Company_Badges_RepoTests
    {
        BadgesRepo _badgeRepo = new BadgesRepo();
        [TestInitialize]
        public void Arrange()
        {
            Badge badge = new Badge();
            List<string> doors = new List<string>();
            badge.BadgeID = 00001;
            badge.Name = "Austin";
            doors.Add("A6");
            doors.Add("A5");
            doors.Add("A4");
            badge.DoorAccess = doors;
            _badgeRepo.CreateANewBadge(badge);
        }

        [TestMethod]
        public void CreateANewBadge_BadgeIsNull_ReturnFalse()
        {
            Badge newBadge = null;

            bool result = _badgeRepo.CreateANewBadge(newBadge);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CreateANewBadge_BadgeIsNotNull_ReturnTrue()
        {
            Badge newBadge = new Badge();

            bool result = _badgeRepo.CreateANewBadge(newBadge);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FindBadgeByBadgeNumber_BadgeExsists_ReturnBadge()
        {
            int id = 00001;

            Badge result = _badgeRepo.FindBadgeByBadgeNumber(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.BadgeID);
        }
        [TestMethod]
        public void FindBadgeByBadgeNumber_BadgeDoesNotExsist_ReturnNull()
        {
            int id = 12021;

            Badge result = _badgeRepo.FindBadgeByBadgeNumber(id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void UpdateABadge_BadgeDoesExsist_ReturnTrue()
        {
            int id = 00001;
            Badge newBadge = new Badge();

            bool result = _badgeRepo.UpdateABadge(id, newBadge);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdateABadge_BadgeDoesExsist_PropertyCheck()
        {
            int id = 00001;
            Badge newBadge = new Badge();
            newBadge.BadgeID = 00003;
            newBadge.Name = "Katelyn";

            bool result = _badgeRepo.UpdateABadge(id, newBadge);

            Assert.IsTrue(result);
            Assert.AreEqual("Katelyn", newBadge.Name);
        }
        [TestMethod]
        public void UpdateABadge_BadgeDoesNotExsist_ReturnFalse()
        {
            int id = 00003;
            Badge newBadge = new Badge();

            bool result = _badgeRepo.UpdateABadge(id, newBadge);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void DeleteABadge_BadgeDoesExsist_ReturnTrue()
        {
            int id = 00001;

            bool result = _badgeRepo.DeleteABadge(id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void DeleteABadge_BadgeDoesNotExsist_ReturnFalse()
        {
            int id = 00005;

            bool result = _badgeRepo.DeleteABadge(id);

            Assert.IsFalse(result);
        }
    }
}
