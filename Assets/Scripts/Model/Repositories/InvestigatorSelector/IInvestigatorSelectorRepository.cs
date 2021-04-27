namespace Arkham.Repositories
{
    public interface IInvestigatorSelectorRepository
    {
        void Add(string investigatorId);
        void Remove(string investigatorId);
        void SelectCurrent(string investigatorId);
        void SelectLead();
        void SelectCurrentOrLead();
        void Swap(int positionToSwap, string investigatorId);
    }
}
