namespace CtrlAltQuest.Pathfinder2e.Ancestry;

public static partial class AncestryReferences
{
    public static List<IAncestry> CommonAncestries = new List<IAncestry>()
    {
        Dwarf.Instance,
        Elf.Instance,
        Gnome.Instance,
        Halfling.Instance,
        Human.Instance,
        Leshy.Instance,
        Orc.Instance
    };
}

public class Dwarf : IAncestry
{
    public static Dwarf Instance => new Dwarf();
    public string Name => "Dwarf";
    public string ShortDescription => "Dwarves are a short, stocky people who are often stubborn, fierce, and devoted.";
    public string Description => "Dwarves have a well-earned reputation as a stoic and stern people, but they also have an unbridled zeal and deeply value artisanship. To a stranger, they can seem untrusting and clannish, but to their friends and family, they are warm and caring. While trust from a dwarf is hard-won, once gained it is as strong as iron.";

    public string InfoLink => "https://2e.aonprd.com/Ancestries.aspx?ID=59";
    public string KnownFor => "Resilient, stoic, and tradition-bound, dwarves often embody determination and pride in their crafts and heritage";
    public string PairWellWith => "Fighter, Cleric, Ranger";
    public string KeyAttributes => "High Constitution and Wisdom, with excellent fortitude and durability";
    public List<string> TypicalCharacteristics =>
    [
        "Hard as nails",
        "Stubborn and unrelenting adventurer",
        "Rugged toughness and deep wisdom",
        "Recognize the deep connection you have with your family, heritage, and friends."
    ];

    public int BaseHitPoints => 10;

    public Size Size => Size.Medium;

    public int BaseSpeed => 20;

    public List<string> AttributeBoosts => 
    [
        "Constitution",
        "Wisdom",
        "Free"
    ];

    public List<string> AttributeFlaws =>
    [
        "Charisma"
    ];

    public List<string> BaseLanguages => 
    [
        "Common",
        "Dwarven"
    ];

    public List<Ability> Abilities => 
    [
        new ("Darkvision", "You can see in darkness and dim light just as well as you can see in bright light, though your vision in darkness is in black and white."),
        new ("Clan Dagger", "You get one clan dagger for free, as it was given to you at birth. Selling this clan dagger is a terrible taboo and earns you the disdain of other dwarves.")
    ];

    public List<Trait> Traits => 
    [
        Trait.Dwarf,
        Trait.Humanoid
    ];

    public string Description1 => "Dwarves have a well-earned reputation as a stoic and stern people, but they also have an unbridled zeal and deeply value artisanship. To a stranger, they can seem untrusting and clannish, but to their friends and family, they are warm and caring. While trust from a dwarf is hard-won, once gained it is as strong as iron.";

    public string Description2 => "If you want to play a character who is as hard as nails, a stubborn and unrelenting adventurer, with a mix of rugged toughness and deep wisdom, you should play a dwarf.";

    public List<string> YouMight => ["Strive to uphold your personal honor and refuse to back down","Appreciate quality craftsmanship in all forms and insist upon it for all your gear"];

    public List<string> OthersProbably => ["See you as stubborn, though whether this is an asset or a detriment changes from moment to moment", "Recognize the deep connection you have with your family, heritage, and friends"];
}

public class Elf : IAncestry
{
    public static Elf Instance => new Elf();
    public string Name => "Elf";

    public string ShortDescription => "Elves are a tall, long-lived people with a strong tradition of art and magic.";

    public string Description => "As an ancient people, elves have seen great change and have the perspective that can come only from watching the arc of history. Elves value kindness, intellect, and beauty, with many elves striving to improve their manners, appearance, and culture. Elves are often rather private people, steeped in the secrets of their groves and kinship groups. They're slow to build friendships outside their kinsfolk, as elves who spend their lives among shorter-lived peoples often become morose after watching generations of companions age and die.";

    public string InfoLink => "https://2e.aonprd.com/Ancestries.aspx?ID=60";
    public string KnownFor => "Graceful and perceptive, elves are often wise or enigmatic, with a deep connection to nature or magic";
    public string PairWellWith => "Wizard, Rogue, Ranger";
    public string KeyAttributes => "High Dexterity and Intelligence, with a natural affinity for speed and magic";

    public List<string> TypicalCharacteristics => 
    [
        "Tall, long-lived people with a strong tradition of art and magic",
        "Magical, mystical, and mysterious",
        "Carefully curate relationships with people with shorter lifespans",
        "Adopt specialized or obscure interests simply for the sake of mastering them"
    ];

    public int BaseHitPoints => 6;

    public Size Size => Size.Medium;

    public int BaseSpeed => 30;

    public List<string> AttributeBoosts =>
    [
        "Dexterity",
        "Intelligence",
        "Free"
    ];

    public List<string> AttributeFlaws =>
    [
        "Constitution"
    ];

    public List<string> BaseLanguages =>
    [
        "Common",
        "Elven"
    ];

    public List<Ability> Abilities => 
    [
        new ("Low-Light Vision", "You can see in dim light as though it were bright light, so you ignore the concealed condition due to dim light.")
    ];

    public List<Trait> Traits => 
    [
        Trait.Elf,
        Trait.Humanoid
    ];

    public string Description1 => "As an ancient people, elves have seen great change and have the perspective that can come only from watching the arc of history. After leaving Golarion in ancient times, they returned to a changed land, and they still struggle to reclaim their ancestral homes. Elves value kindness, intellect, and beauty, with many elves striving to improve their manners, appearance, and culture. Their studies delve into a level of detail that most shorter-lived peoples find excessive or inefficient. Elves are often rather private people, steeped in the secrets of their groves and kinship groups. They're slow to build friendships outside their kinsfolk, as elves who spend their lives among shorter-lived peoples often become morose after watching generations of companions age and die. These elves are known as Forlorn among their fellow elves.";

    public string Description2 => "";

    public List<string> YouMight => 
    [
        "Carefully curate your relationships with people with shorter lifespans",
        "Adopt specialized or obscure interests simply for the sake of mastering them"
    ];

    public List<string> OthersProbably => 
    [
        "Focus on your appearance, either admiring your grace or treating you as if you're physically fragile",
        "Worry that you privately look down on them, or feel like you're condescending and aloof"
    ];
}

public class Gnome : IAncestry
{
    public static Gnome Instance => new Gnome();
    public string Name => "Gnome";
    public string ShortDescription => "Gnomes are short and hardy folk, with an unquenchable curiosity and eccentric habits.";
    public string Description => "Always hungry for new experiences, gnomes constantly wander both mentally and physically, attempting to stave off a terrible ailment that threatens all of their people. This affliction, known as the Bleaching, strikes gnomes who fail to dream, innovate, and take in new experiences. The Bleaching slowly drains the color— literally—from gnomes, and it plunges those affected into states of deep depression that eventually claim their lives. Very few gnomes survive this scourge, becoming deeply morose and wise survivors known as bleachlings.";

    public string InfoLink => "https://2e.aonprd.com/Ancestries.aspx?ID=61";
    public string KnownFor => "Curious and eccentric, gnomes bring color and wonder to any group, with an insatiable thirst for new experiences";
    public string PairWellWith => "Bard, Sorcerer, Druid";
    public string KeyAttributes => "High Charisma and Constitution, with innate magic and adaptability";

    public List<string> TypicalCharacteristics =>
    [
        "Embrace learning and hop from one area of study to another without warning",
        "Speak, think, and move quickly, and lose patience with those who can't keep up",
        "Appreciate your enthusiasm and the energy with which you approach new situations",
        "Struggle to understand your motivations or adapt to your rapid changes of direction"
    ];

    public int BaseHitPoints => 8;

    public Size Size => Size.Small;

    public int BaseSpeed => 25;

    public List<string> AttributeBoosts => 
    [
        "Constitution",
        "Charisma",
        "Free"
    ];

    public List<string> AttributeFlaws =>
    [
        "Strength"
    ];

    public List<string> BaseLanguages => 
    [
        "Common",
        "Fey",
        "Gnomish"
    ];

    public List<Ability> Abilities => 
    [
        new ("Low-light Vision", "You can see in dim light as though it were bright light, so you ignore the concealed condition due to dim light.")
    ];

    public List<Trait> Traits => 
    [
        Trait.Gnome,
        Trait.Humanoid
    ];

    public string Description1 => "Long ago, early gnome ancestors emigrated from the First World, realm of the fey. While it's unclear why the first gnomes wandered to Golarion, this lineage manifests in modern gnomes as bizarre reasoning, eccentricity, obsessive tendencies, and what some see as naivete.";

    public string Description2 => "Always hungry for new experiences, gnomes constantly wander both mentally and physically, attempting to stave off a terrible ailment that threatens all of their people. This affliction, known as the Bleaching, strikes gnomes who fail to dream, innovate, and take in new experiences. The Bleaching slowly drains the color— literally—from gnomes, and it plunges those affected into states of deep depression that eventually claim their lives. Very few gnomes survive this scourge, becoming deeply morose and wise survivors known as bleachlings.";

    public List<string> YouMight => 
    [
        "Embrace learning and hop from one area of study to another without warning",
        "Speak, think, and move quickly, and lose patience with those who can't keep up"
    ];

    public List<string> OthersProbably => throw new NotImplementedException();
}

public class Goblin : IAncestry
{
    public static Goblin Instance => new Goblin();
    public string Name => "Goblin";
    public string ShortDescription => "Goblins are a short, scrappy, energetic people who have spent millennia maligned and feared.";
    public string Description => "The convoluted histories other people cling to don't interest goblins. These small folk live in the moment, and they prefer tall tales over factual records. Goblin virtues are about being present, creative, and honest. They strive to lead fulfilled lives, rather than worrying about how their journeys will end. To tell stories, not nitpick the facts. To be small, but dream big. Many goblins enjoy simpler delights like songs, fire, and eating, and hate reading, dogs, and horses. Other goblins might have more complex pursuits, though, such as tinkering with scraps or concocting snacks and explosives from most anything.";

    public string InfoLink => "https://2e.aonprd.com/Ancestries.aspx?ID=62";
    public string KnownFor => "Mischievous, resourceful, and often chaotic, goblins are spirited and bring surprising ingenuity to problem-solving";
    public string PairWellWith => "Alchemist, Rogue, Bard";
    public string KeyAttributes => "High Dexterity and Charisma, with unique fire and explosive affinities";

    public List<string> TypicalCharacteristics =>
    [
        "Strive to prove that you have a place among other civilized peoples, perhaps even to yourself",
        "Lighten the heavy emotional burdens others carry (and amuse yourself) with antics and pranks",
        "Work to ensure you don't accidentally (or intentionally) set too many things on fire",
        "Wonder how you survive given your ancestry's typical gastronomic choices, reckless behavior, and love of fire"
    ];

    public int BaseHitPoints => 6;

    public Size Size => Size.Small;

    public int BaseSpeed => 25;

    public List<string> AttributeBoosts => 
    [
        "Dexterity",
        "Charisma",
        "Free"
    ];

    public List<string> AttributeFlaws =>
    [
        "Wisdom"
    ];

    public List<string> BaseLanguages => 
    [
        "Common",
        "Goblin"
    ];

    public List<Ability> Abilities => 
    [
        new ("DarkVision", "You can see in darkness and dim light just as well as you can see in bright light, though your vision in darkness is in black and white.")
    ];

    public List<Trait> Traits => 
    [
        Trait.Goblin,
        Trait.Humanoid
    ];

    public string Description1 => "The convoluted histories other people cling to don't interest goblins. These small folk live in the moment, and they prefer tall tales over factual records. Goblin virtues are about being present, creative, and honest. They strive to lead fulfilled lives, rather than worrying about how their journeys will end. To tell stories, not nitpick the facts. To be small, but dream big. Many goblins enjoy simpler delights like songs, fire, and eating, and hate reading, dogs, and horses. Other goblins might have more complex pursuits, though, such as tinkering with scraps or concocting snacks and explosives from most anything.";

    public string Description2 => "";

    public List<string> YouMight => 
    [
        "Strive to prove that you have a place among other civilized peoples, perhaps even to yourself",
        "Lighten the heavy emotional burdens others carry (and amuse yourself) with antics and pranks"
    ];

    public List<string> OthersProbably =>
    [
        "Work to ensure you don't accidentally (or intentionally) set too many things on fire",
        "Wonder how you survive given your ancestry's typical gastronomic choices, reckless behavior, and love of fire"
    ];
}

public class Halfling : IAncestry
{
    public static Halfling Instance => new();
    public string Name => "Halfling";
    public string ShortDescription => "Halflings are a short, resilient people who exhibit remarkable curiosity and humor.";
    public string Description => "Claiming no place as their own, halflings control few settlements larger than villages. Instead, they frequently live among humans within larger cities, carving out small communities alongside taller folk. Optimistic, cheerful, and driven by powerful wanderlust, halflings make up for their short stature with an abundance of bravado. At once excitable and easygoing, halflings are the best kind of opportunists, and their passions favor joy over violence. While their curiosity sometimes drives them toward adventure, halflings also carry strong ties to house and home.";

    public string InfoLink => "https://2e.aonprd.com/Ancestries.aspx?ID=63";
    public string KnownFor => "Optimistic and community-driven, halflings are brave and resourceful, with a knack for making the best of any situation";
    public string PairWellWith => "Rogue, Bard, Monk";
    public string KeyAttributes => "High Dexterity and Charisma, with a focus on luck, agility, and adaptability";

    public List<string> TypicalCharacteristics =>
    [
        "Get along well with a wide variety of people and enjoy meeting new friends",
        "Find it difficult to resist indulging your curiosity, even when you know it's going to lead to trouble",
        "Appreciate your ability to always find a silver lining or something to laugh about, no matter how dire the situation",
        "Think you bring good luck with you"
    ];

    public int BaseHitPoints => 6;

    public Size Size => Size.Small;

    public int BaseSpeed => 25;

    public List<string> AttributeBoosts => 
    [
        "Dexterity",
        "Wisdom",
        "Free"
    ];

    public List<string> AttributeFlaws =>
    [
        "Strength"
    ];

    public List<string> BaseLanguages => 
    [
        "Common",
        "Halfling"
    ];

    public List<Ability> Abilities => 
    [
        new ("Keen Eyes", "Your eyes are sharp, allowing you to make out small details about concealed or even invisible creatures that others might miss. You gain a +2 circumstance bonus when using the Seek action to find hidden or undetected creatures within 30 feet of you. When you target an opponent that is concealed from you or hidden from you, reduce the DC of the flat check to 3 for a concealed target or 9 for a hidden one.")
    ];

    public List<Trait> Traits => 
    [
        Trait.Halfling,
        Trait.Humanoid
    ];

    public string Description1 => "Claiming no place as their own, halflings control few settlements larger than villages. Instead, they frequently live among humans within larger cities, carving out small communities alongside taller folk. Optimistic, cheerful, and driven by powerful wanderlust, halflings make up for their short stature with an abundance of bravado. At once excitable and easygoing, halflings are the best kind of opportunists, and their passions favor joy over violence. While their curiosity sometimes drives them toward adventure, halflings also carry strong ties to house and home.";

    public string Description2 => "";

    public List<string> YouMight => 
    [
        "Get along well with a wide variety of people and enjoy meeting new friends",
        "Find it difficult to resist indulging your curiosity, even when you know it's going to lead to trouble"
    ];

    public List<string> OthersProbably => 
    [
        "Appreciate your ability to always find a silver lining or something to laugh about, no matter how dire the situation",
        "Think you bring good luck with you"
    ];
}

public class Human : IAncestry
{
    public static Human Instance => new();
    public string Name => "Human";
    public string ShortDescription => "Humans are diverse and adaptable people with wide potential and deep ambitions.";
    public string Description => "Humans' ambition, versatility, and exceptional potential have led to their status as the world's predominant ancestry. Their empires and nations are vast, sprawling things, and their citizens carve names for themselves with the strength of their sword arms and the power of their spells. Humanity is diverse and tumultuous, running the gamut from nomadic to imperial, sinister to saintly. Many of them venture forth to explore, to map the expanse of the multiverse, to search for long-lost treasure, or to lead mighty armies to conquer their neighbors—for no better reason than because they can.";

    public string InfoLink => "https://2e.aonprd.com/Ancestries.aspx?ID=64";
    public string KnownFor => "Versatile and ambitious, humans excel at adaptation and have a strong drive to make their mark in the world";
    public string PairWellWith => "Any class, especially Fighter, Sorcerer, and Cleric";
    public string KeyAttributes => "Flexible ability boosts, allowing humans to fit well into any class";

    public List<string> TypicalCharacteristics =>
    [
        "Strive to achieve greatness, either in your own right or on behalf of a cause",
        "Seek to understand your purpose in the world",
        "Cherish your relationships with family and friends",
        "Respect your flexibility, your adaptability, and—in most cases—your open-mindedness",
        "Distrust your intentions, fearing you seek only power or wealth",
        "Aren't sure what to expect from you and are hesitant to assume your intentions"
    ];

    public int BaseHitPoints => 8;

    public Size Size => Size.Medium;

    public int BaseSpeed => 25;

    public List<string> AttributeBoosts => 
    [
        "Free",
        "Free"
    ];

    public List<string> AttributeFlaws =>
    [ ];

    public List<string> BaseLanguages => 
    [
        "Common"
    ];

    public List<Ability> Abilities => 
    [ ];

    public List<Trait> Traits => 
    [
        Trait.Human,
        Trait.Humanoid
    ];

    public string Description1 => "As unpredictable and varied as any of Golarion's peoples, humans have exceptional drive and the capacity to endure and expand. Though many civilizations thrived before humanity rose to prominence, humans have built some of the greatest and the most terrible societies throughout the course of history, and today they are the most populous people in the realms around the Inner Sea.";

    public string Description2 => "Humans' ambition, versatility, and exceptional potential have led to their status as the world's predominant ancestry. Their empires and nations are vast, sprawling things, and their citizens carve names for themselves with the strength of their sword arms and the power of their spells. Humanity is diverse and tumultuous, running the gamut from nomadic to imperial, sinister to saintly. Many of them venture forth to explore, to map the expanse of the multiverse, to search for long-lost treasure, or to lead mighty armies to conquer their neighbors—for no better reason than because they can.";

    public List<string> YouMight => 
    [
        "Strive to achieve greatness, either in your own right or on behalf of a cause",
        "Seek to understand your purpose in the world",
        "Cherish your relationships with family and friends",
    ];

    public List<string> OthersProbably => 
    [
        "Respect your flexibility, your adaptability, and—in most cases—your open-mindedness",
        "Distrust your intentions, fearing you seek only power or wealth",
        "Aren't sure what to expect from you and are hesitant to assume your intentions"
    ];
}

public class Leshy : IAncestry
{
    public static Leshy Instance => new();
    public string Name => "Leshy";
    public string ShortDescription => "Leshies are immortal nature spirits placed in small plant bodies, seeking to experience the world.";
    public string Description => "Leshies are immortal spirits of nature temporarily granted physical forms. As guardians and emissaries of the environment, leshies are “born” when a skilled druid or other master of primal magic conducts a ritual to create a suitable vessel, and then a spirit chooses that vessel to be their temporary home. Leshies are self-sufficient from the moment the ritual ends, though it isn't uncommon for leshies to maintain lifelong bonds with their creators. Many leshies relish the opportunity to interact with the physical world. While most leshy spirits are ancient, they rarely recall past lifetimes and see their new life as a chance to experience the wonders of the world once more.";

    public string InfoLink => "https://2e.aonprd.com/Ancestries.aspx?ID=65";
    public string KnownFor => "Playful and nature-bound, leshies are plant-like beings with a deep bond to the natural world and a curious, gentle outlook";
    public string PairWellWith => "Druid, Ranger, Cleric";
    public string KeyAttributes => "High Wisdom and Constitution, with abilities tied to plants and survival in wilderness environments";

    public List<string> TypicalCharacteristics =>
    [
        "Act as a traveling agent for natural guardians who are unable to leave their territories",
        "Encourage civilizations to cooperate with nature and build their cities in ecologically friendly ways",
        "Think you are a curiosity due to your spiritual origins",
        "Assume you know only about nature and are unfamiliar with civilization and society"
    ];

    public int BaseHitPoints => 8;

    public Size Size => Size.Small;

    public int BaseSpeed => 25;

    public List<string> AttributeBoosts => 
    [
        "Constitution",
        "Wisdom",
        "Free"
    ];

    public List<string> AttributeFlaws =>
    [
        "Intelligence"
    ];

    public List<string> BaseLanguages => 
    [
        "Common",
        "Fey"
    ];

    public List<Ability> Abilities => 
    [
        new ("Low-light Vision", "You can see in dim light as though it were bright light, so you ignore the concealed condition due to dim light."),
        new ("Plant Nourishment", "You gain nourishment in the same way that the plants or fungi that match your body type normally do, through some combination of photosynthesis, absorbing minerals with your roots, or scavenging decaying matter. You typically do not need to pay for food. If you normally rely on photosynthesis and go without sunlight for 1 week, you begin to starve. You can derive nourishment from specially formulated bottles of sunlight instead of natural sunlight, but these bottles cost 10 times as much as standard rations (or 40 sp).")
    ];

    public List<Trait> Traits => 
    [
        Trait.Leshy,
        Trait.Plant
    ];

    public string Description1 => "Leshies are immortal spirits of nature temporarily granted physical forms. As guardians and emissaries of the environment, leshies are “born” when a skilled druid or other master of primal magic conducts a ritual to create a suitable vessel, and then a spirit chooses that vessel to be their temporary home. Leshies are self-sufficient from the moment the ritual ends, though it isn't uncommon for leshies to maintain lifelong bonds with their creators. Many leshies relish the opportunity to interact with the physical world. While most leshy spirits are ancient, they rarely recall past lifetimes and see their new life as a chance to experience the wonders of the world once more.";

    public string Description2 => "";

    public List<string> YouMight => 
    [
        "Act as a traveling agent for natural guardians who are unable to leave their territories",
        "Encourage civilizations to cooperate with nature and build their cities in ecologically friendly ways"
    ];

    public List<string> OthersProbably =>
    [
        "Think you are a curiosity due to your spiritual origins",
        "Assume you know only about nature and are unfamiliar with civilization and society"
    ];
}

public class Orc : IAncestry
{
    public static Orc Instance => new();
    public string Name => "Orc";
    public string ShortDescription => "Orcs are proud, strong people with hardened physiques who value physical might and glory in combat.";
    public string Description => "Orcs are forged in the fires of violence and conflict, often from the moment they are born. As they live lives that are frequently cut brutally short, orcs revel in testing their strength against worthy foes, often by challenging a higher-ranking member of their community for dominance. Orcs often struggle to gain acceptance among other communities, who frequently see them as brutes. Those who earn the loyalty of an orc friend, however, soon learn that an orc's fidelity and honesty are unparalleled. Orc culture teaches that they are shaped by the challenges they survive, and the most worthy survive the most hardships. Orcs who attain both a long life and great triumphs command immense respect.";

    public string InfoLink => "https://2e.aonprd.com/Ancestries.aspx?ID=66";
    public string KnownFor => "Fierce and proud, orcs are known for their physical prowess, bravery, and strong warrior culture";
    public string PairWellWith => "Barbarian, Fighter, Champion";
    public string KeyAttributes => "High Strength and Constitution, excelling in raw power and resilience in combat";
    public List<string> TypicalCharacteristics =>
    [
        "Eagerly meet any chance to prove your strength in a physical contest",
        "View dying in glorious combat as preferable to a mundane death from old age or illness",
        "Others see you as violent or lacking in discipline",
        "Others admire your forthrightness and blunt honesty"
    ];

    public int BaseHitPoints => 10;

    public Size Size => Size.Medium;

    public int BaseSpeed => 25;

    public List<string> AttributeBoosts => 
    [
        "Free",
        "Free"
    ];

    public List<string> AttributeFlaws =>
    [ ];

    public List<string> BaseLanguages => 
    [
        "Common",
        "Orcish"
    ];

    public List<Ability> Abilities => 
    [
        new ("Darkvision", "You can see in darkness and dim light just as well as you can see in bright light, though your vision in darkness is in black and white.")
    ];

    public List<Trait> Traits => 
    [
        Trait.Orc,
        Trait.Humanoid
    ];

    public string Description1 => "Orcs are forged in the fires of violence and conflict, often from the moment they are born. As they live lives that are frequently cut brutally short, orcs revel in testing their strength against worthy foes, often by challenging a higher-ranking member of their community for dominance. Orcs often struggle to gain acceptance among other communities, who frequently see them as brutes. Those who earn the loyalty of an orc friend, however, soon learn that an orc's fidelity and honesty are unparalleled. Orc culture teaches that they are shaped by the challenges they survive, and the most worthy survive the most hardships. Orcs who attain both a long life and great triumphs command immense respect.";

    public string Description2 => "";

    public List<string> YouMight => 
    [
        "Eagerly meet any chance to prove your strength in a physical contest",
        "View dying in glorious combat as preferable to a mundane death from old age or illness"
    ];

    public List<string> OthersProbably => 
    [
        "See you as violent or lacking in discipline",
        "Admire your forthrightness and blunt honesty"
    ];
}