namespace Arkham.Views
{
    public interface IInvestigatorSelectorsManager
    {
        InvestigatorSelectorView GetLeadSelector { get; }
        InvestigatorSelectorView GetEmptySelector();
        InvestigatorSelectorView GetSelectorById(string cardId);
        void ResetSelectors();
        void ArrangeAllSelectors();
        void RebuildPlaceHolders();
    }
}
