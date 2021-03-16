using Arkham.EventData;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class InitializeGame : MonoBehaviour
    {
        [Inject] private readonly IStartGame startGame;

        /*******************************************************************/
        public void NewGame() => startGame.NewGame();
    }
}
