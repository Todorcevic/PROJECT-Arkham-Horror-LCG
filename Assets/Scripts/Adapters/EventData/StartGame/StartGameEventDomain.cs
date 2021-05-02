using Arkham.Config;
using System;

namespace Arkham.Adapter
{
    public class StartGameEventDomain
    {
        private event Action<StartGame> GameStarted;

        /*******************************************************************/
        public void Init(StartGame gameType) => GameStarted?.Invoke(gameType);

        public void Subscribe(Action<StartGame> action) => GameStarted += action;
    }
}
