using GoldBadgeChallenge_4_Company_Outings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GoldBadgeChallengesRepositories
{
    [TestClass]
    public class Challenge_4_Company_Outings_RepositoryTests
    {
        private CompanyOutingsRepository _repo = new CompanyOutingsRepository();
        private List<CompanyOuting> outingsList = new List<CompanyOuting>();
        [TestInitialize]
        public void Arrange()
        {
            CompanyOuting outing = new CompanyOuting();
            _repo.CreateNewOuting(outing);
            outingsList.Add(outing);
        }
        [TestMethod]
        public void CreateNewOuting_OutingIsNull_ReturnFalse()
        {
            CompanyOuting testOuting = null;

            bool result = _repo.CreateNewOuting(testOuting);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CreateNewOuting_OutingIsNotNull_ReturnTrue()
        {
            CompanyOuting testOuting = new CompanyOuting();

            bool result = _repo.CreateNewOuting(testOuting);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FindOutingByID_OutingDoesNotExsist_ReturnNull()
        {
            int id = 5;

            CompanyOuting result = _repo.FindOutingByID(id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void FindOutingByID_OutingDoesExist_ReturnClaim()
        {
            int id = 1;

            CompanyOuting result = _repo.FindOutingByID(id);

            Assert.AreEqual(result.OutingID, id);
            Assert.IsNotNull(result);
        }
    }
}
