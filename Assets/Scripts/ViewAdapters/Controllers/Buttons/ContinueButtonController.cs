using Arkham.EventData;
using Zenject;

namespace Arkham.Controllers
{
    public class ContinueButtonController : ButtonController
    {
        [Inject] private readonly IStartGame startGame;

        /*******************************************************************/
        private void Start() => clickAction.AddListener(startGame.ContinueGame);
    }
}
