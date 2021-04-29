using System;
using Zenject;

namespace Arkham.Model
{
    public class UnlockCardEventDomain
    {
        [Inject] private readonly UnlockCardRepository unlockCardsRepository;
        public event Action CardUnlocked;

        /*******************************************************************/
        public void Add(string cardId)
        {
            unlockCardsRepository.UnlockCards.Add(cardId);
            CardUnlocked?.Invoke();
        }
    }
}
