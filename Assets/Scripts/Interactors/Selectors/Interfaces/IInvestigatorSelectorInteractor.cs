namespace Arkham.Interactors
{
    public interface IInvestigatorSelectorInteractor
    {
        string LeadInvestigator { get; }
        bool SelectionIsFull { get; }
        int AmontInvestigatorsSelected { get; }
        bool CanThisCardBeSelected(string cardId);
        bool CanThisCardBeShowed(string cardId);
    }
}
