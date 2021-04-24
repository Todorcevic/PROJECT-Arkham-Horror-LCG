using Zenject;

namespace Arkham.Views
{
    public class CardShowerController : ICardShowerController
    {
        [Inject] private readonly ICardShowerPresenter showCardPresenter;

        /*******************************************************************/
        public void HoveredOn(CardShowerDTO showCardDTO) => showCardPresenter.Show(showCardDTO);

        public void HoveredOff() => showCardPresenter.Hide();
    }
}
