using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.Aggregators;
using CtrlAltQuest.Pathfinder2e.SystemData;
using Xunit;

namespace CtrlAltQuest.Pathfinder2e.Tests.AggregatorTests
{
    public class SkillsAggregatorTests
    {
        private Pathfinder2eCharacter _character = new Pathfinder2eCharacter()
        {
            CharacterId = new Common.CharacterId(Guid.NewGuid()),
            Strength = 2,
            Dexterity = 3,
            Constitution = 4,
            Wisdom = 5,
            Charisma = 6,
            Intelligence = 7,
            Level = 3
        };

        [Fact]
        public void SkillsAggreagtor_AllUntrained()
        {
            /* Strength */
            Assert.Equal(2, SkillsAggregator.CalculateAthletics(_character));
            
            /* Dexterity */
            Assert.Equal(3, SkillsAggregator.CalculateAcrobatics(_character));
            Assert.Equal(3, SkillsAggregator.CalculateStealth(_character));
            Assert.Equal(3, SkillsAggregator.CalculateThievery(_character));

            /* Wisdom */
            Assert.Equal(5, SkillsAggregator.CalculateMedicine(_character));
            Assert.Equal(5, SkillsAggregator.CalculateNature(_character));
            Assert.Equal(5, SkillsAggregator.CalculateReligion(_character));
            Assert.Equal(5, SkillsAggregator.CalculateSurvival(_character));

            /* Charisma */
            Assert.Equal(6, SkillsAggregator.CalculateDeception(_character));
            Assert.Equal(6, SkillsAggregator.CalculateDiplomacy(_character));
            Assert.Equal(6, SkillsAggregator.CalculateIntimidation(_character));
            Assert.Equal(6, SkillsAggregator.CalculatePerformance(_character));

            /* Intelligence */
            Assert.Equal(7, SkillsAggregator.CalculateArcana(_character));
            Assert.Equal(7, SkillsAggregator.CalculateCrafting(_character));
            Assert.Equal(7, SkillsAggregator.CalculateOccultism(_character));
            Assert.Equal(7, SkillsAggregator.CalculateSociety(_character));
            Assert.Equal(7, SkillsAggregator.CalculateLore(_character, Proficiency.Untrained));
        }

        [Fact]
        public void SkillsAggreagtor_Mixed()
        {
            var character = _character with
            {
                SkillProficiencies = new SkillProficiencies()
                {
                    Athletics = Proficiency.Trained,
                    Acrobatics = Proficiency.Expert,
                    Stealth = Proficiency.Master,
                    Thievery = Proficiency.Legendary,
                    Medicine = Proficiency.Trained,
                    Nature = Proficiency.Expert,
                    Religion = Proficiency.Master,
                    Survival = Proficiency.Legendary,
                    Deception = Proficiency.Trained,
                    Diplomacy = Proficiency.Expert,
                    Intimidation = Proficiency.Master,
                    Performance = Proficiency.Legendary,
                    Arcana = Proficiency.Trained,
                    Crafting = Proficiency.Expert,
                    Occultism = Proficiency.Master,
                    Society = Proficiency.Legendary,
                }
            };
            /* Strength */
            Assert.Equal(7, SkillsAggregator.CalculateAthletics(character));

            /* Dexterity */
            Assert.Equal(10, SkillsAggregator.CalculateAcrobatics(character));
            Assert.Equal(12, SkillsAggregator.CalculateStealth(character));
            Assert.Equal(14, SkillsAggregator.CalculateThievery(character));

            /* Wisdom */
            Assert.Equal(10, SkillsAggregator.CalculateMedicine(character));
            Assert.Equal(12, SkillsAggregator.CalculateNature(character));
            Assert.Equal(14, SkillsAggregator.CalculateReligion(character));
            Assert.Equal(16, SkillsAggregator.CalculateSurvival(character));

            /* Charisma */
            Assert.Equal(11, SkillsAggregator.CalculateDeception(character));
            Assert.Equal(13, SkillsAggregator.CalculateDiplomacy(character));
            Assert.Equal(15, SkillsAggregator.CalculateIntimidation(character));
            Assert.Equal(17, SkillsAggregator.CalculatePerformance(character));

            /* Intelligence */
            Assert.Equal(12, SkillsAggregator.CalculateArcana(character));
            Assert.Equal(14, SkillsAggregator.CalculateCrafting(character));
            Assert.Equal(16, SkillsAggregator.CalculateOccultism(character));
            Assert.Equal(18, SkillsAggregator.CalculateSociety(character));
            Assert.Equal(12, SkillsAggregator.CalculateLore(character, Proficiency.Trained));
        }
        
        /*
         * TODO: Add tests for magical items that boost specific skills
         * */
    }
}
