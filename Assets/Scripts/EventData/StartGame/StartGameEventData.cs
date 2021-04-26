using Arkham.Services;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class StartGameEventData : IStartGame, IStartGameEvent
    {
        [Inject] private readonly IDataPersistence dataPersistence;
        private event Action GameStarted;

        /*******************************************************************/
        void IStartGame.NewGame()
        {
            dataPersistence.LoadProgress(isNewGame: true);
            GameStarted?.Invoke();
        }

        void IStartGame.ContinueGame()
        {
            dataPersistence.LoadProgress(isNewGame: false);
            GameStarted?.Invoke();
        }

        void IStartGameEvent.AddAction(Action action) => GameStarted += action;
    }
}
