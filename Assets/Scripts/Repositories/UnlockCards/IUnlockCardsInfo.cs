namespace Arkham.Repositories
{
    public interface IUnlockCardsInfo
    {
        bool IsThisCardUnlocked(string cardId);
    }
}
