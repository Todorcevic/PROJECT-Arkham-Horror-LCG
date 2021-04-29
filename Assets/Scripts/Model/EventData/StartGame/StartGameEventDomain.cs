using System;

namespace Arkham.Model
{
    public enum StartGame { New, Continue }

    public class StartGameEventDomain
    {
        public event Action<StartGame> GameStarted;

        /*******************************************************************/
        public void Init(StartGame gameType) => GameStarted?.Invoke(gameType);
    }
}
