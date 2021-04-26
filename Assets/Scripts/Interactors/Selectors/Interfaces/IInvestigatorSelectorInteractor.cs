namespace Arkham.Interactors
{
    public interface IInvestigatorSelectorInteractor
    {
        bool CanThisCardBeSelected(string cardId);
        bool CanThisCardBeShowed(string cardId);
    }
}
