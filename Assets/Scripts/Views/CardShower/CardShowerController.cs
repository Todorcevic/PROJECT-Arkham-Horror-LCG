using Zenject;

namespace Arkham.View
{
    public class CardShowerController : ICardShowerController
    {
        [Inject] private readonly ICardShowerPresenter showCardPresenter;

        /*******************************************************************/
        public void HoveredOn(CardShowerDTO showCardDTO) => showCardPresenter.Show(showCardDTO);

        public void HoveredOff() => showCardPresenter.Hide();
    }
}
