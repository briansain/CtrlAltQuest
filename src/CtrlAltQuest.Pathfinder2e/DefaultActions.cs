using CtrlAltQuest.Pathfinder2e.SystemData;

namespace CtrlAltQuest.Pathfinder2e
{
    public static class DefaultActions
    {
        public static List<CharacterAction> Basic = new List<CharacterAction>()
        {
            new CharacterAction()
            {
                Title = "Crawl",
                Link = "https://2e.aonprd.com/Actions.aspx?ID=2293",
                Requirements = "You are prone and your Speed is at least 10 feet.",
                Description = "Move 5 feet while prone, allowing limited mobility without standing.",
                ActionType = ActionType.Single
            },
            new CharacterAction()
            {
                Title = "Delay",
                Link = "https://2e.aonprd.com/Actions.aspx?ID=2294",
                ActionType = ActionType.Free,
                Trigger = "Your turn begins",
                Description = "Wait to act later in the initiative order by postponing your turn to better respond to the evolving situation."
            },
            new CharacterAction()
            {
                Title = "Drop Prone",
                ActionType = ActionType.Single,
                Traits = new List<Trait>() {Trait.Move},
                Link = "https://2e.aonprd.com/Actions.aspx?ID=2295",
                Description = "Fall prone intentionally to gain bonuses against ranged attacks but at the cost of reduced mobility and melee effectiveness."
            },
            new CharacterAction()
            {
                Title = "Escape",
                ActionType = ActionType.Single,
                Link = "https://2e.aonprd.com/Actions.aspx?ID=2296",
                Traits = new List<Trait> { Trait.Attack },
                Description = "Break free from restraints, grapples, or other effects limiting your mobility, relying on an Acrobatics or Athletics check."
            },
            new CharacterAction()
            {
                Title = "Interact",
                ActionType = ActionType.Single,
                Link = "https://2e.aonprd.com/Actions.aspx?ID=2297",
                Traits = new List<Trait> { Trait.Manipulate },
                Description = "Manipulate an object or feature of your environment, such as drawing a weapon, opening a door, or picking up an item."
            },
            new CharacterAction()
            {
                Title = "Leap",
                ActionType = ActionType.Single,
                Link = "https://2e.aonprd.com/Actions.aspx?ID=2298",
                Traits = new List<Trait> { Trait.Move },
                Description = "Jump vertically (up to 3 feet vertically and 5 feet horizontally) or horizontally (up to 10 feet if your speed is at least 15 feet, up 10 15 feet if your speed is at least 30 feet)."
            },
            new CharacterAction()
            {
                Title = "Ready",
                ActionType = ActionType.Double,
                Link = "https://2e.aonprd.com/Actions.aspx?ID=2299",
                Traits = new List<Trait> { Trait.Concentrate },
                Description = "Set up a single action or reaction with a trigger condition to respond tactically when specific circumstances occur."
            },
            new CharacterAction()
            {
                Title = "Release",
                ActionType = ActionType.Free,
                Link = "https://2e.aonprd.com/Actions.aspx?ID=2300",
                Traits = new List<Trait> { Trait.Manipulate },
                Description = "Let go of an object or creature you're holding as a free action, freeing your hands for other actions or interactions."
            },
            new CharacterAction()
            {
                Title = "Seek",
                ActionType = ActionType.Single,
                Link = "https://2e.aonprd.com/Actions.aspx?ID=2301",
                Traits = new List<Trait> { Trait.Concentrate, Trait.Secret },
                Description = "Use a Perception check to search your surroundings for hidden creatures, objects, or traps, helping you uncover details others might miss."
            },
            new CharacterAction()
            {
                Title = "Sense Motive",
                ActionType = ActionType.Single,
                Link = "https://2e.aonprd.com/Actions.aspx?ID=2302",
                Traits = new List<Trait> { Trait.Concentrate, Trait.Secret },
                Description = "Use your Perception to detect a creature's intentions, emotions, or whether it's lying. This action helps you gain insight during conversations or tense encounters, often revealing hidden motives or deceptions."
            },
            new CharacterAction()
            {
                Title = "Stand",
                ActionType = ActionType.Single,
                Link = "https://2e.aonprd.com/Actions.aspx?ID=2303",
                Traits = new List<Trait> { Trait.Move },
                Description = "Rise from a prone position, regaining your full mobility but potentially provoking reactions from enemies."
            },
            new CharacterAction()
            {
                Title = "Step",
                ActionType = ActionType.Single,
                Link = "https://2e.aonprd.com/Actions.aspx?ID=2304",
                Traits = new List<Trait> { Trait.Move },
                Requirements = "Your speed is at least 10 feet.",
                Description = "Move 5 feet without triggering reactions, allowing you to reposition safely, especially in tight combat situations.",
            },
            new CharacterAction()
            {
                Title = "Strike",
                ActionType = ActionType.Single,
                Link = "https://2e.aonprd.com/Actions.aspx?ID=2306",
                Traits = new List<Trait> { Trait.Attack },
                Description = "Make a melee or ranged attack using your weapon, unarmed strike, or spell attack, often dealing damage and applying other effects based on the weapon or ability used."
            },
            new CharacterAction()
            {
                Title = "Take Cover",
                ActionType = ActionType.Single,
                Link = "https://2e.aonprd.com/Actions.aspx?ID=2307",
                Requirements = "You are benefiting from cover, are near a feature that allows you to take cover, or are prone.",
                Description = "Enhance your defenses against ranged attacks and area effects by using environmental cover to reduce incoming damage."
            }
        };
    }
}
