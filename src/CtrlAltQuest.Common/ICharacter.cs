namespace CtrlAltQuest.Common
{
    public interface ICharacter
    {
        CharacterId CharacterId { get; init; }
        UserId UserId { get; init; }
        string Name { get; init; }

    }
}
