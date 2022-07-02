using Arkham.Model;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class SelectPlayerUseCase
    {
        [Inject] private readonly PlayersRepository playersRepository;
        [Inject] private readonly ZonesManager zonesManager;
        [Inject] private readonly CardMovementPresenter cardMovementPresenter;

        /*******************************************************************/
        public void Select(Player player)
        {
            Player playerToDeselect = playersRepository.PlayerSelected;
            UpdateModel(player);
            UpdateView(player, playerToDeselect);
        }

        private void UpdateModel(Player player) => playersRepository.PlayerSelected = player;

        private void UpdateView(Player playerToSelect, Player playerToDeselect)
        {
            zonesManager.SelectedPlayerZones(playerToSelect);
            zonesManager.DeselectPlayerZones(playerToDeselect);

            foreach (Card card in playerToSelect.Deck)
            {
                cardMovementPresenter.MoveCard(card, card.CurrentZone);
            }
        }
    }
}
