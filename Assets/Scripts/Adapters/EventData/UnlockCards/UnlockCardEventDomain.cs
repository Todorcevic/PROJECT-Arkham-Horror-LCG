using Arkham.Model;
using System;
using Zenject;

namespace Arkham.Adapter
{
    public class UnlockCardEventDomain
    {
        [Inject] private readonly UnlockCardsRepository unlockCards;
        [Inject] private readonly CardRepository cardCollection;
        private event Action CardUnlocked;

        /*******************************************************************/
        public void Add(string cardId)
        {
            Card card = cardCollection.Get(cardId);
            unlockCards.Add(card);
            CardUnlocked?.Invoke();
        }

        public void Subscribe(Action action) => CardUnlocked += action;
    }
}
