using Arkham.Entities;
using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.Interactors
{
    public class CurrentInvestigatorInteractor : IInvestigatorSelectedInfo, ICardAddedEvent, ICardRemovedEvent, IInvestigatorSelected
    {
        private event Action<string> DeckCardAdded;
        private event Action<string> DeckCardRemoved;
        [Inject] private readonly IInvestigatorSelectorInfo investigatorSelectorInfo;
        [Inject] private readonly IInvestigatorInfo investigatorRepository;

        public InvestigatorInfo Info =>
            investigatorRepository.Get(investigatorSelectorInfo.CurrentInvestigatorSelected);

        /*******************************************************************/
        public void AddCard(string deckCardId)
        {
            Info.Deck.Add(deckCardId);
            DeckCardAdded?.Invoke(deckCardId);
        }

        public bool RemoveCard(string cardId)
        {
            if (IsMandatoryCard(cardId)) return false;
            Info.Deck.Remove(cardId);
            DeckCardRemoved?.Invoke(cardId);
            return true;
        }

        void ICardAddedEvent.AddAction(Action<string> action) => DeckCardAdded += action;

        void ICardRemovedEvent.AddAction(Action<string> action) => DeckCardRemoved += action;

        private bool IsMandatoryCard(string cardId) => Info.MandatoryCards.Contains(cardId);
    }
}
