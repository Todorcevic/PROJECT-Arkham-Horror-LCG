namespace Arkham.Views
{
    public interface ICardSelectorView : ISelectorView
    {
        void SetName(string cardName);
        void SetQuantity(int quantity);
        void ClickEffect();
        void HoverOnEffect();
        void HoverOffEffect();
    }
}
