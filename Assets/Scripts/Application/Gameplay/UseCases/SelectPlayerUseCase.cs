using Arkham.Model;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class SelectPlayerUseCase
    {
        [Inject] private readonly PlayersRepository playersRepository;
        [Inject] private readonly SwapPlayerPresenter swapPlayerPresenter;

        /*******************************************************************/
        public void Select(Player player)
        {
            UpdateModel(player);
            UpdateView(player);
        }

        private void UpdateModel(Player player) => playersRepository.PlayerSelected = player;

        private void UpdateView(Player playerToSelect) => swapPlayerPresenter.Select(playerToSelect);
    }
}
