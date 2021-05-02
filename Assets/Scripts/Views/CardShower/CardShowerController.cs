using Zenject;

namespace Arkham.Views
{
    public class CardShowerController
    {
        [Inject] private readonly CardShowerPresenter showCardPresenter;

        /*******************************************************************/
        public void HoveredOn(CardShowerDTO showCardDTO) => showCardPresenter.Show(showCardDTO);

        public void HoveredOff() => showCardPresenter.Hide();
    }
}
