using Arkham.EventData;
using Zenject;

namespace Arkham.Controllers
{
    public class NewGameButtonController : ButtonController
    {
        [Inject] private readonly IStartGame startGame;
        [Inject] private readonly IChangeScenario changeScenario;

        /*******************************************************************/
        private void Start() => clickAction.AddListener(NewGame);

        public void NewGame()
        {
            startGame.NewGame();
            changeScenario.SelectingScenario(null);
        }
    }
}
