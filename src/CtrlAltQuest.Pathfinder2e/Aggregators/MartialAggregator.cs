using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.SystemData;
using System.Dynamic;

namespace CtrlAltQuest.Pathfinder2e.Aggregators
{
    public class MartialAggregator : BaseAggregator
    {
        public static int GetArmorBonus(Pathfinder2eCharacter characterState)
        {
            var equippedArmor = EquipmentAggregator.GetEquippedArmor(characterState);
            var armorProficiencyBonus = 0;
            var armorItemBonus = 0;
            var dexterityBonus = characterState.Dexterity;
            if (equippedArmor != null)
            {
                armorProficiencyBonus = GetArmorProficiencyBonus(characterState, equippedArmor.ArmorCategory);
                armorItemBonus = equippedArmor.ArmorBonus;
                dexterityBonus = GetAbilityWithCap(characterState.Dexterity, equippedArmor.DexterityCap);
            }
            return 10 + dexterityBonus + armorProficiencyBonus + armorItemBonus;
        }


        public static int GetArmorProficiencyBonus(Pathfinder2eCharacter character, ArmorCategory armorCategory)
        {
            switch (armorCategory)
            {
                case ArmorCategory.Unarmored:
                    return CalculateProficiency(character.MartialProficiencies.Unarmored, character.Level);
                case ArmorCategory.Light:
                    return CalculateProficiency(character.MartialProficiencies.LightArmor, character.Level);
                case ArmorCategory.Medium:
                    return CalculateProficiency(character.MartialProficiencies.MediumArmor, character.Level);
                case ArmorCategory.Heavy:
                    return CalculateProficiency(character.MartialProficiencies.HeavyArmor, character.Level);
                default:
                    return CalculateProficiency(Proficiency.Untrained, character.Level);
            }
        }

		public static List<Attack> GetAttacks(Pathfinder2eCharacter character)
		{
			var weapons = EquipmentAggregator.GetEquippedWeapons(character);
			var attacks = new List<Attack>();
			
			foreach (var weapon in weapons ?? [])
			{
				var damageModifier = GetDamageModifier(character, weapon);
				var attackBonus = GetAttackBonus(character, weapon);
				var attack = new Attack()
				{
					Name = weapon.Name,
					AttackBonus = attackBonus >= 0 ? $"+{attackBonus}" : $"-{attackBonus}", //get attack bonus
					Damage = $"{weapon.NumDamageDice}{Enum.GetName(weapon.DamageDice)} {(damageModifier >= 0 ? $"+{damageModifier}" : $"-{damageModifier}")} ({GetDamageTypes(weapon.DamageTypes, weapon.WeaponTraits)})",
					Traits = GetTraitStrings(weapon.WeaponTraits),
					Range = weapon.Range != null ? $"{weapon.Range}ft" : string.Empty,
					Reload = weapon.Reload,
					WeaponType = Enum.GetName(weapon.WeaponType) ?? string.Empty
				};
				attacks.Add(attack);
				if (weapon.WeaponTraits.Any(w => w == WeaponTrait.Thrown_10 || w == WeaponTrait.Thrown_20))
				{
					attacks.Add(attack with
					{
						WeaponType = Enum.GetName(WeaponType.Range) ?? string.Empty,
						Range = weapon.WeaponTraits.Any(w => w == WeaponTrait.Thrown_10) ? "10ft" : "20ft",
						Reload = 1
					});
				}
			}

			return attacks;
		}
		private static List<string> GetTraitStrings(List<WeaponTrait> weaponTraits)
		{
			var output = weaponTraits.Select(w => Enum.GetName(w).Replace("_", " "));
			return output.ToList();
		}

		private static int GetAttackBonus(Pathfinder2eCharacter character, Weapon weapon)
		{
			if (weapon.WeaponType == WeaponType.Melee && weapon.WeaponTraits.Any(w => w == WeaponTrait.Finesse))
			{
				return Math.Max(character.Strength, character.Dexterity);
			}
			else if (weapon.WeaponType == WeaponType.Melee)
			{
				return character.Strength;
			}
			return character.Dexterity;
		}

		private static int GetDamageModifier(Pathfinder2eCharacter character, Weapon weapon)
		{
			if (weapon.WeaponType == WeaponType.Melee)
			{
				return character.Strength;
			}
			else if (weapon.WeaponTraits.Any(w => w == WeaponTrait.Thrown))
			{
				return character.Strength;
			}
			else if (weapon.WeaponTraits.Any(w => w == WeaponTrait.Propulsive))
			{
				return character.Strength > 0 ? (int)Math.Floor(character.Strength / 2.0) : character.Strength;
			}

			return 0;
		}

		private static string GetDamageTypes(List<DamageType> damageTypes, List<WeaponTrait> weaponTraits)
		{
			var output = new HashSet<string>();
			foreach (var damageType in damageTypes)
			{
				output.Add(damageType switch
				{
					DamageType.Bludgoning => "B",
					DamageType.Slashing => "S",
					DamageType.Piercing => "P",
					_ => throw new NotImplementedException()
				});
			}
			foreach (var weaponTrait in weaponTraits)
			{
				var w = weaponTrait switch
				{
					WeaponTrait.Versatile_B => "B",
					WeaponTrait.Versatile_S => "S",
					WeaponTrait.Versatile_P => "P",
					_ => null
				};
				if (!string.IsNullOrEmpty(w))
				{
					output.Add(w);
				}
			}
			return string.Join("/", output);
		}

		public record Attack
		{
			public string Name { get; set; } = string.Empty;
			public string AttackBonus { get; set; }
			public string Damage { get; set; } = string.Empty;
			public List<string> Traits { get; set; } = [];
			public string Range { get; set; } = string.Empty;
			public int? Reload { get; set; }
			public string WeaponType { get; set; } = string.Empty;
		}
	}
}
