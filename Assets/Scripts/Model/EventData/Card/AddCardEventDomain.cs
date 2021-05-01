using System;
using Zenject;

namespace Arkham.Model
{
    public class AddCardEventDomain
    {
        private event Action<string> CardAdded;
        [Inject] private readonly Selector selectorRepository;
        [Inject] private readonly CardRepository cardRepository;

        /*******************************************************************/
        public void AddCard(string cardId)
        {
            Card card = cardRepository.Get(cardId);
            selectorRepository.InvestigatorSelected.AddToDeck(card);
            CardAdded?.Invoke(cardId);
        }

        public void Subscribe(Action<string> action) => CardAdded += action;
    }
}
