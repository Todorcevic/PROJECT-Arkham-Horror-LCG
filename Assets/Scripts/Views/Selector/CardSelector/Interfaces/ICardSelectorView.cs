namespace Arkham.Views
{
    public interface ICardSelectorView : ISelectorView
    {
        void ActiveSelector(bool isActive);
        void SetName(string cardName);
        void SetQuantity(int amount);
    }
}
