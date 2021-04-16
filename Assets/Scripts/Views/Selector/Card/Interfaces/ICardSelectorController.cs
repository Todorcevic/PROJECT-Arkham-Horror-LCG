namespace Arkham.Views
{
    public interface ICardSelectorController
    {
        void Clicked(string cardId);
        void HoveredOn(ShowCardDTO showCardDTO);
        void HoveredOff();
    }
}
