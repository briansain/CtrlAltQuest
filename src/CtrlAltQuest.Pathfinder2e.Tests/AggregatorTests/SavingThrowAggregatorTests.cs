using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.Aggregators;
using Xunit;

namespace CtrlAltQuest.Pathfinder2e.Tests.AggregatorTests
{
    public class SavingThrowAggregatorTests
    {
        private Pathfinder2eCharacter _character = new Pathfinder2eCharacter()
        {
            CharacterId = new Common.CharacterId(Guid.NewGuid()),
            Constitution = 2,
            Wisdom = 3,
            Dexterity = 4,

            Level = 2
        };

        [Fact]
        public void SavingThrowAggregator_Default()
        {
            var fortitudeSavingThrow = SavingThrowAggregator.GetFortitudeSavingThrow(_character);
            var reflexSavingThrow = SavingThrowAggregator.GetReflexSavingThrow(_character);
            var willSavingThrow = SavingThrowAggregator.GetWillSavingThrow(_character);

            Assert.Equal(2, fortitudeSavingThrow);
            Assert.Equal(4, reflexSavingThrow);
            Assert.Equal(3, willSavingThrow);
        }

        [Fact]
        public void SavingThrowAggregator_Trained()
        {
            var character = _character with
            {
                SavingThrowProficiencies = new SavingThrowProficiencies()
                {
                    FortitudeSavingThrow = SystemData.Proficiency.Trained,
                    ReflexSavingThrow = SystemData.Proficiency.Expert,
                    WillSavingThrow = SystemData.Proficiency.Master
                }
            };
            var fortitudeSavingThrow = SavingThrowAggregator.GetFortitudeSavingThrow(character);
            var reflexSavingThrow = SavingThrowAggregator.GetReflexSavingThrow(character);
            var willSavingThrow = SavingThrowAggregator.GetWillSavingThrow(character);

            Assert.Equal(6, fortitudeSavingThrow);
            Assert.Equal(10, reflexSavingThrow);
            Assert.Equal(11, willSavingThrow);
        }
    }
}
