﻿using BusinessLogic.DataAccess;
using BusinessLogic.Logic.Users;
using BusinessLogic.Models.User;
using NUnit.Framework;

namespace BusinessLogic.Tests.IntegrationTests.LogicTests.UserContextBuilderImplTests
{
    [TestFixture]
    public class GetUserContextIntegrationTests : IntegrationTestBase
    {
        private UserContextBuilderImpl contextBuilder;
        private UserContext userContext;

        [TestFixtureSetUp]
        public void SetUp()
        {
            using(NemeStatsDbContext dbContext = new NemeStatsDbContext())
            {
                contextBuilder = new UserContextBuilderImpl();
                userContext = contextBuilder.GetUserContext(testUserContextForUserWithDefaultGamingGroup.ApplicationUserId, dbContext);
            }
        }

        [Test]
        public void ItSetsTheUserId()
        {
            Assert.AreEqual(testUserContextForUserWithDefaultGamingGroup.ApplicationUserId, userContext.ApplicationUserId);
        }

        [Test]
        public void ItSetsTheCurrentGamingGroupId()
        {
            Assert.AreEqual(testGamingGroup.Id, userContext.GamingGroupId);
        }
    }
}
