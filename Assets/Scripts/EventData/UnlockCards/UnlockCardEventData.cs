using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class UnlockCardEventData : IUnlockCard, IUnlockCardEvent
    {
        [Inject] private readonly Repository repository;
        private event Action CardUnlocked;

        /*******************************************************************/
        void IUnlockCard.UnlockCard(string cardId)
        {
            repository.UnlockCards.Add(cardId);
            CardUnlocked?.Invoke();
        }

        void IUnlockCardEvent.AddAction(Action action) => CardUnlocked += action;
    }
}
