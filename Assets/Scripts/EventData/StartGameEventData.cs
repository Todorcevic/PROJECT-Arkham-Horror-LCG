using Arkham.Entities;
using Arkham.Services;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class StartGameEventData : IStartGame, IStartGameEvent
    {
        [Inject] private readonly IDataPersistence dataPersistence;
        public event Action GameStarted;

        /*******************************************************************/
        public void NewGame()
        {
            dataPersistence.NewGame();
            GameStarted?.Invoke();
        }

        public void ContinueGame()
        {
            dataPersistence.LoadProgress();
            GameStarted?.Invoke();
        }
    }
}
