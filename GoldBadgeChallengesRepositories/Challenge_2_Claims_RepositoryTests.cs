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
            Queue<Claim> claimQueue = new Queue<Claim>();
        [TestInitialize]
        public void Arrange() 
        {
            Claim claim = new Claim();
            _claimsRepository.CreateClaim(claim);
            claimQueue.Enqueue(claim);
        }
        
        [TestMethod]
        public void CreateClaim_ClaimIsNull_ReturnFalse()
        {
            //Arrange
            Claim claim = null;
            //Act
            bool result = _claimsRepository.CreateClaim(claim);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CreateClaim_ClaimIsNotNull_ReturnTrue()
        {
            Claim claimTest = new Claim();
            bool result = _claimsRepository.CreateClaim(claimTest);
            Assert.IsTrue(result);
        }     
        [TestMethod]
        public void FindClaimById_ClaimDoesExsist_ReturnClaim()
        {
            int id = 1;
            Claim result = _claimsRepository.FindClaimById(id);
            Assert.AreEqual(result.ClaimID, id);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void FintClaimById_ClaimDoesNotExsist_ReturnNull()
        {
            int id = 10;
            Claim result = _claimsRepository.FindClaimById(id);
            
            Assert.IsNull(result);
        }
    }
}
