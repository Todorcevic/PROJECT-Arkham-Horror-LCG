namespace Arkham.Views
{
    public interface ICardSelectorController
    {
        void Clicked(string cardId);
        void HoveredOn(CardShowerDTO showCardDTO);
        void HoveredOff();
    }
}
