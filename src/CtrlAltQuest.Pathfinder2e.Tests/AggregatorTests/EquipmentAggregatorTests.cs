using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.Aggregators;
using CtrlAltQuest.Pathfinder2e.SystemData;
using Xunit;

namespace CtrlAltQuest.Pathfinder2e.Tests.AggregatorTests
{
    public class EquipmentAggregatorTests
    {
        private Pathfinder2eCharacter _character = new Pathfinder2eCharacter
        {
            CharacterId = new Common.CharacterId(Guid.NewGuid())
        };

        [Fact]
        public void EquipmentAggregator_AllNull()
        {
            var armor = EquipmentAggregator.GetEquippedArmor(_character);
            var shield = EquipmentAggregator.GetEquippedShield(_character);
            var weapons = EquipmentAggregator.GetEquippedWeapons(_character);

            Assert.Null(armor);
            Assert.Null(shield);
            Assert.NotNull(weapons);
            Assert.Empty(weapons);
        }

        [Fact]
        public void EquipmentAggregator_ShieldEquipped()
        {
            var character = _character with
            {
                Equipment = [
                    new Shield()
                    {
                        Name = "EquippedShield",
                        IsEquipped = true,
                        ItemCategory = ItemCategory.Shield
                    },
                    new Shield()
                    {
                        Name = "NOTEquippedShield",
                        IsEquipped = false,
                        ItemCategory = ItemCategory.Shield
                    }]
            };
            var armor = EquipmentAggregator.GetEquippedArmor(character);
            var shield = EquipmentAggregator.GetEquippedShield(character);
            var weapons = EquipmentAggregator.GetEquippedWeapons(character);

            Assert.Null(armor);
            Assert.NotNull(weapons);
            Assert.Empty(weapons);
            Assert.NotNull(shield);
            Assert.Equal("EquippedShield", shield.Name);
        }

        [Fact]
        public void EquipmentAggregator_ArmorEquipped()
        {
            var character = _character with
            {
                Equipment = [
                    new Armor()
                    {
                        Name = "EquippedArmor",
                        IsEquipped = true,
                        ItemCategory = ItemCategory.Armor,
                        ArmorBonus = 2,
                        ArmorCategory = ArmorCategory.Light
                    },
                    new Armor()
                    {
                        Name = "NOTEquippedArmor",
                        IsEquipped = false,
                        ItemCategory = ItemCategory.Armor,
                        ArmorBonus = 2,
                        ArmorCategory = ArmorCategory.Light
                    }]
            };
            var armor = EquipmentAggregator.GetEquippedArmor(character);
            var shield = EquipmentAggregator.GetEquippedShield(character);
            var weapons = EquipmentAggregator.GetEquippedWeapons(character);

            Assert.Null(shield);
            Assert.NotNull(weapons);
            Assert.Empty(weapons);
            Assert.NotNull(armor);
            Assert.Equal("EquippedArmor", armor.Name);
        }

        [Fact]
        public void EquipmentAggregator_Weapons()
        {
            var character = _character with
            {
                Equipment = [
                    new Weapon()
                    {
                        Name = "EquippedWeapon",
                        IsEquipped = true,
                        ItemCategory = ItemCategory.Weapon
                    },
                    new Weapon()
                    {
                        Name = "NOTEquippedWeapon",
                        IsEquipped = false,
                        ItemCategory = ItemCategory.Weapon
                    }]
            };
            var armor = EquipmentAggregator.GetEquippedArmor(character);
            var shield = EquipmentAggregator.GetEquippedShield(character);
            var weapons = EquipmentAggregator.GetEquippedWeapons(character);

            Assert.Null(shield);
            Assert.Null(armor);
            Assert.NotNull(weapons);
            Assert.Single(weapons);
        }
    }
}
