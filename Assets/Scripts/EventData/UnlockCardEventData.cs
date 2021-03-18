using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class UnlockCardEventData : IUnlockCard, IUnlockCardEvent
    {
        [Inject] private readonly Repository repository;
        public event Action<string> CardUnlocked;

        /*******************************************************************/
        public void UnlockCard(string cardId)
        {
            repository.UnlockCards.Add(cardId);
            CardUnlocked?.Invoke(cardId);
        }
    }
}
