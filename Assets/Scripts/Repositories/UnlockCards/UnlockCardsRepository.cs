using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Arkham.Repositories
{
    [DataContract]
    public class UnlockCardsRepository : IUnlockCardsLoader, IUnlockCardsRepository, ICardUnlockedEvent, IUnlockCardsInfo
    {
        private event Action CardUnlocked;
        [DataMember] public List<string> UnlockCards { get; set; } = new List<string>();

        /*******************************************************************/
        public void Add(string cardId)
        {
            UnlockCards.Add(cardId);
            CardUnlocked?.Invoke();
        }

        public bool IsThisCardUnlocked(string cardId) => UnlockCards.Contains(cardId);

        public void Subscribe(Action action) => CardUnlocked += action;
    }
}
