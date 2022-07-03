using Arkham.Model;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class SwapPlayerPresenter
    {
        private Player currentSelected = new NullPlayer();
        [Inject] private readonly ZonesManager zonesManager;
        [Inject] private readonly CardMovementPresenter cardMovementPresenter;

        /*******************************************************************/
        public void Select(Player playerSelected)
        {
            zonesManager.DeselectPlayerZones(currentSelected);
            zonesManager.SelectedPlayerZones(playerSelected);

            foreach (Card card in currentSelected.Deck)
            {
                cardMovementPresenter.MoveCard(card, card.CurrentZone);
            }

            foreach (Card card in playerSelected.Deck)
            {
                cardMovementPresenter.MoveCard(card, card.CurrentZone);
            }

            currentSelected = playerSelected;
        }
    }
}
