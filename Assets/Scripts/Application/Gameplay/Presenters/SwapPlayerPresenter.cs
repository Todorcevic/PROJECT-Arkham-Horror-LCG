using Arkham.Model;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class SwapPlayerPresenter
    {
        private Player currentSelected;
        [Inject] private readonly ZonesManager zonesManager;
        [Inject] private readonly CardMovementPresenter cardMovementPresenter;

        /*******************************************************************/
        public void Select(Player playerSelected)
        {
            zonesManager.DeselectPlayerZones(currentSelected);
            zonesManager.SelectedPlayerZones(playerSelected);

            currentSelected?.Deck.ForEach(card => cardMovementPresenter.MoveCard(card, card.CurrentZone));
            playerSelected.Deck.ForEach(card => cardMovementPresenter.MoveCard(card, card.CurrentZone));
            currentSelected = playerSelected;
        }
    }
}
