﻿using BusinessLogic.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Tests.UnitTests.LogicTests.PlayersTests.PlayerRetrieverTests
{
    [TestFixture]
    public class GetAllPlayersWithNemesisInfoTests : PlayerRetrieverTestBase
    {
        [Test]
        public void ItOnlyReturnsPlayersForTheGivenGamingGroup()
        {
            List<Player> players = playerRetriever.GetAllPlayersWithNemesisInfo(gamingGroupId);

            Assert.True(players.All(player => player.GamingGroupId == gamingGroupId));
        }

        [Test]
        public void ItReturnsPlayersOrderedByTheirNameAscending()
        {
            List<Player> players = playerRetriever.GetAllPlayersWithNemesisInfo(gamingGroupId);

            string lastPlayerName = "0";
            foreach (Player player in players)
            {
                Assert.LessOrEqual(lastPlayerName, player.Name);
                lastPlayerName = player.Name;
            }
        }
    }
}