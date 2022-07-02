using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class PlayerFactoryService
    {
        [Inject] private readonly DiContainer diContainer;
        [Inject] private readonly PlayersRepository playerRepository;

        /*******************************************************************/
        public Player BuildPlayer()
        {
            Player newPlayer = new Player();
            diContainer.Inject(newPlayer);
            playerRepository.AddPlayer(newPlayer);
            return newPlayer;
        }
    }
}
