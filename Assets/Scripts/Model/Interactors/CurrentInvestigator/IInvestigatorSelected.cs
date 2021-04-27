namespace Arkham.Interactors
{
    public interface IInvestigatorSelected
    {
        void AddCard(string cardId);
        bool RemoveCard(string cardId);
    }
}
