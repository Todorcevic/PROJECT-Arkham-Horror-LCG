using Arkham.Model;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class MoveCardUseCase
    {
        [Inject] private readonly CardMovementPresenter cardMovementPresenter;

        /*******************************************************************/
        public void MoveCard(Card card, Zone zone)
        {
            UpdateModel(card, zone);
            UpdateView(card, zone);
        }

        private void UpdateModel(Card card, Zone zone) => card.CurrentZone = zone;

        private void UpdateView(Card card, Zone zone) => cardMovementPresenter.MoveCard(card, zone);
    }
}
