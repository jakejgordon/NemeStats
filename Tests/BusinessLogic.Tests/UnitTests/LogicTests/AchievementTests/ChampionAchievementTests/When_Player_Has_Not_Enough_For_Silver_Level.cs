using System.Linq;
using BusinessLogic.Models;
using BusinessLogic.Models.Achievements;
using NUnit.Framework;
using Rhino.Mocks;

namespace BusinessLogic.Tests.UnitTests.LogicTests.AchievementTests.ChampionAchievementTests
{
    [TestFixture]
    public class When_Player_Has_Not_Enough_For_Silver_Level : Base_ChampionAchievementTest
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            this.InsertChampionedGames(Achievement.LevelThresholds[AchievementLevel.Bronze]+1, this.PlayerId);
            this.InsertChampionedGames(1, OtherPlayerId);
            DataContext.Stub(s => s.GetQueryable<Champion>()).Return(ChampionedGames.AsQueryable());
        }

        [Test]
        public void Then_Returns_Bronze_Achievement()
        {
            var result = Achievement.IsAwardedForThisPlayer(PlayerId, DataContext);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.LevelAwarded.HasValue);

            Assert.That(result.LevelAwarded.Value, Is.EqualTo(AchievementLevel.Bronze));
            foreach (var championedGame in ChampionedGames.Where(c => c.PlayerId == PlayerId))
            {
                Assert.IsTrue(result.RelatedEntities.Contains(championedGame.GameDefinitionId));
            }
        }
    }
}