using Arkham.Model;
using System.Collections.Generic;
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

            foreach (Card card in currentSelected?.Deck ?? new List<Card>())
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
