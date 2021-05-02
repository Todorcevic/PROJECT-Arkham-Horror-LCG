using Arkham.Model;
using System;
using Zenject;

namespace Arkham.Adapter
{
    public class RemoveCardEventDomain
    {
        private event Action<string> CardRemoved;
        [Inject] private readonly Selector selector;
        [Inject] private readonly CardRepository cardCollection;

        /*******************************************************************/
        public bool RemoveCard(string cardId)
        {
            Card card = cardCollection.Get(cardId);
            if (selector.InvestigatorSelected.IsMandatoryCard(card)) return false;
            selector.InvestigatorSelected.RemoveToDeck(card);
            CardRemoved?.Invoke(cardId);
            return true;
        }

        public void Subscribe(Action<string> action) => CardRemoved += action;
    }
}
