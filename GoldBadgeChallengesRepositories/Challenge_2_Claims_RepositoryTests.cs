using GoldBadgeChallenge_2_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GoldBadgeChallengesRepositories
{
    [TestClass]
    public class Challenge_2_Claims_RepositoryTests
    {
            ClaimsRepository _claimsRepository = new ClaimsRepository();
            Queue<Claims> claimQueue = new Queue<Claims>();
        [TestInitialize]
        public void Arrange() 
        {
            Claims claim = new Claims();
            _claimsRepository.CreateClaim(claim);
            claimQueue.Enqueue(claim);
        }
        
        [TestMethod]
        public void CreateClaim_ClaimIsNull_ReturnFalse()
        {
            //Arrange
            Claims claim = null;
            //Act
            bool result = _claimsRepository.CreateClaim(claim);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CreateClaim_ClaimIsNotNull_ReturnTrue()
        {
            Claims claimTest = new Claims();
            bool result = _claimsRepository.CreateClaim(claimTest);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdateAClaim_ClaimDoesNotExsist_ReturnFalse()
        {
            int id = 2;
            Claims testClaim = new Claims();
            bool result = _claimsRepository.UpdateAClaim(id, testClaim);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void UpdateAClaim_ClaimDoesExsist_ReturnTrue()
        {
            int id = 1;
            Claims testClaim = new Claims();
            bool result = _claimsRepository.UpdateAClaim(id, testClaim);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdateAClaim_ClaimDoesExsist_PropertiesChange()
        {
            int id = 1;
            Claims testClaim = new Claims("Updated", 23.21);
            bool result = _claimsRepository.UpdateAClaim(id, testClaim);
            Assert.AreEqual("Updated", testClaim.Description);
            Assert.AreEqual(23.21, testClaim.ClaimAmount);
        }
        [TestMethod]
        public void DequeueAClaim_ClaimDoesNotExsist_ReturnFalse()
        {
            int id = 85;

            bool result = _claimsRepository.DeQueueAClaim(id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void DequeueAClaim_ClaimDoesExsist_ReturnTrue()
        {
            int id = 1;

            bool result = _claimsRepository.DeQueueAClaim(id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FindClaimById_ClaimDoesExsist_ReturnClaim()
        {
            int id = 1;
            Claims result = _claimsRepository.FindClaimById(id);
            Assert.AreEqual(result.ClaimID, id);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void FintClaimById_ClaimDoesNotExsist_ReturnNull()
        {
            int id = 10;
            Claims result = _claimsRepository.FindClaimById(id);
            
            Assert.IsNull(result);
        }
    }
}
