﻿using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DataAccess;
using BusinessLogic.Logic.Achievements;
using BusinessLogic.Models;
using BusinessLogic.Models.Achievements;
using NUnit.Framework;
using Rhino.Mocks;
using StructureMap.AutoMocking;

namespace BusinessLogic.Tests.UnitTests.LogicTests.AchievementTests
{
    [TestFixture]
    public class NemePointsAchievementTests
    {
        private RhinoAutoMocker<NemePointsAchievement> _autoMocker;
        private readonly int _playerId = 1;

        [SetUp]
        public void SetUp()
        {
            _autoMocker = new RhinoAutoMocker<NemePointsAchievement>();
        }

        [Test]
        public void ItDoesNotAwardTheAchievementWhenThePlayerDoesNotReachTheBronzeThreshold()
        {
            //--arrange
            AddPointsForPlayer(_playerId, _autoMocker.ClassUnderTest.LevelThresholds[AchievementLevel.Bronze] - 1);

            //--act
            var results = _autoMocker.ClassUnderTest.IsAwardedForThisPlayer(_playerId);

            //--assert
            Assert.That(results.LevelAwarded, Is.Null);
        }

        [Test]
        public void ItAwardsBronzeWhenPlayerHasExactlyBronzeNumberOfPlayedGames()
        {
            //--arrange
            AddPointsForPlayer(_playerId, _autoMocker.ClassUnderTest.LevelThresholds[AchievementLevel.Bronze]);

            //--act
            var results = _autoMocker.ClassUnderTest.IsAwardedForThisPlayer(_playerId);

            //--assert
            Assert.That(results.LevelAwarded, Is.EqualTo(AchievementLevel.Bronze));
        }

        [Test]
        public void ItAwardsSilverWhenPlayerHasExactlySilverNumberOfPlayedGames()
        {
            //--arrange
            AddPointsForPlayer(_playerId, _autoMocker.ClassUnderTest.LevelThresholds[AchievementLevel.Silver]);

            //--act
            var results = _autoMocker.ClassUnderTest.IsAwardedForThisPlayer(_playerId);

            //--assert
            Assert.That(results.LevelAwarded, Is.EqualTo(AchievementLevel.Silver));
        }

        [Test]
        public void ItAwardsGoldWhenPlayerHasExactlyGoldNumberOfPlayedGames()
        {
            //--arrange
            AddPointsForPlayer(_playerId, _autoMocker.ClassUnderTest.LevelThresholds[AchievementLevel.Gold]);

            //--act
            var results = _autoMocker.ClassUnderTest.IsAwardedForThisPlayer(_playerId);

            //--assert
            Assert.That(results.LevelAwarded, Is.EqualTo(AchievementLevel.Gold));
        }

        private void AddPointsForPlayer(int playerId, int points)
        {
            var playerGameResults = new List<PlayerGameResult>
            {
                new PlayerGameResult
                {
                    PlayerId = playerId,
                    NemeStatsPointsAwarded = points
                }
            };

            _autoMocker.Get<IDataContext>().Expect(mock => mock.GetQueryable<PlayerGameResult>()).Return(playerGameResults.AsQueryable());
        }
    }
}
