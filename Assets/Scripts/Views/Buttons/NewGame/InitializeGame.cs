using Arkham.EventData;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class InitializeGame : MonoBehaviour
    {
        [Inject] private readonly IStartGame startGame;
        [Inject] private readonly IChangeScenario changeScenario;
        /*******************************************************************/
        public void NewGame()
        {
            startGame.NewGame();
            changeScenario.SelectScenario(null);
        }
    }
}
