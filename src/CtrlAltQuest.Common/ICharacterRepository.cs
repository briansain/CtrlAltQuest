namespace CtrlAltQuest.Common
{
    public interface ICharacterRepository<TCharacterState> where TCharacterState : ICharacter
    {
        Task<TCharacterState> GetCharacter(CharacterId characterId);
    }
}
