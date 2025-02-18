using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.Aggregators;
using CtrlAltQuest.Pathfinder2e.SystemData;
using Xunit;

namespace CtrlAltQuest.Pathfinder2e.Tests.AggregatorTests
{
    public class MartialAggregatorTests
    {
        private Pathfinder2eCharacter _character = new Pathfinder2eCharacter()
        {
            CharacterId = new Common.CharacterId(Guid.NewGuid()),
            Dexterity = 5,
            Level = 2
        };

        [Fact]
        public void MartialAggregator_ArmorBonus_NoArmor()
        {
            var armorBonus = MartialAggregator.GetArmorBonus(_character);
            Assert.Equal(15, armorBonus);
        }

        [Fact]
        public void MartialAggregator_ArmorBonus_WithArmor_NoDexCap()
        {
            var character = _character with
            {
                Equipment = [
                    new Armor()
                    {
                        Name = "EquippedArmor",
                        IsEquipped = true,
                        ItemCategory = ItemCategory.Armor,
                        ArmorBonus = 3,
                        ArmorCategory = ArmorCategory.Heavy
                    }],
                MartialProficiencies = new MartialProficiencies()
                {
                    LightArmor = Proficiency.Trained,
                    HeavyArmor = Proficiency.Expert
                }
            };

            var armorBonus = MartialAggregator.GetArmorBonus(character);
            Assert.Equal(24, armorBonus);
        }

        [Fact]
        public void MartialAggregator_ArmorBonus_WithArmor_WithDexCap()
        {
            var character = _character with
            {
                Equipment = [
                    new Armor()
                    {
                        Name = "EquippedArmor",
                        IsEquipped = true,
                        ItemCategory = ItemCategory.Armor,
                        ArmorBonus = 3,
                        ArmorCategory = ArmorCategory.Heavy,
                        DexterityCap = 1
                    }],
                MartialProficiencies = new MartialProficiencies()
                {
                    LightArmor = Proficiency.Trained,
                    HeavyArmor = Proficiency.Expert
                }
            };

            var armorBonus = MartialAggregator.GetArmorBonus(character);
            Assert.Equal(20, armorBonus);
        }

        [Fact]
        public void MartialAggregator_GetArmorProficiencyBonus()
        {
            var character = _character with
            {
                MartialProficiencies = new MartialProficiencies()
                {
                    Unarmored = Proficiency.Untrained,
                    LightArmor = Proficiency.Trained,
                    MediumArmor = Proficiency.Expert,
                    HeavyArmor = Proficiency.Master
                }
            };

            var unArmored = MartialAggregator.GetArmorProficiencyBonus(character, ArmorCategory.Unarmored);
            var light = MartialAggregator.GetArmorProficiencyBonus(character, ArmorCategory.Light);
            var medium = MartialAggregator.GetArmorProficiencyBonus(character, ArmorCategory.Medium);
            var heavy = MartialAggregator.GetArmorProficiencyBonus(character, ArmorCategory.Heavy);

            Assert.Equal(0, unArmored);
            Assert.Equal(4, light);
            Assert.Equal(6, medium);
            Assert.Equal(8, heavy);
        }
    }
}
