namespace Arkham.Views
{
    public interface ICardShowerPresenter
    {
        void Show(CardShowerDTO showableCard);
        void Hide();
    }
}
