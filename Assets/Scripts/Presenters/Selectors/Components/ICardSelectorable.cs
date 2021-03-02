namespace Arkham.Presenters
{
    public interface ICardSelectorable : ISelectorable
    {
        void SetName(string cardName);
        void SetQuantity(int amount);
    }
}
