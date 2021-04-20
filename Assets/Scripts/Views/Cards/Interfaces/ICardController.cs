namespace Arkham.Views
{
    public interface ICardController
    {
        void Clicked(string cardId);
        void HoveredOn(CardShowerDTO showCardDTO);
        void HoveredOff();
    }
}
