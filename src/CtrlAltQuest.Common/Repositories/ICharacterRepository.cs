namespace CtrlAltQuest.Common.Repositories
{
    public interface ICharacterRepository<TCharacterState> where TCharacterState : ICharacter
    {
        Task<TCharacterState> GetCharacter(CharacterId characterId);
    }
}
