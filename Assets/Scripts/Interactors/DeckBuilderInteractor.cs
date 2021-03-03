using Arkham.Entities;
using Arkham.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Arkham.Interactors
{
    public class DeckBuilderInteractor : IDeckBuilderInteractor
    {
        [Inject] private readonly IInvestigatorRepository investigatorRepository;
        [Inject] protected readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        public event Action<string> DeckCardAdded;
        public event Action<string> DeckCardRemoved;
        private InvestigatorInfo InvestigatorSelected => GetInvestigatorById(investigatorSelectorInteractor.InvestigatorSelected);
        public int? DeckSize => InvestigatorSelected?.DeckBuilding.DeckSize;
        public int? CardsAmountSelected => InvestigatorSelected?.Deck.Count;
        public bool SelectionIsFull => CardsAmountSelected >= DeckSize;
        public bool SelectionIsNotFull => CardsAmountSelected == DeckSize - 1;

        /*******************************************************************/
        public InvestigatorInfo GetInvestigatorById(string investigatorId) =>
            investigatorRepository.InvestigatorsList.Find(investigator => investigator.Id == investigatorId);

        public void AddDeckCard(string deckCardId)
        {
            InvestigatorSelected.Deck.Add(deckCardId);
            DeckCardAdded?.Invoke(deckCardId);
        }

        public void RemoveDeckCard(string deckCardId)
        {
            InvestigatorSelected.Deck.Remove(deckCardId);
            DeckCardRemoved?.Invoke(deckCardId);
        }

        public bool CanBeSelected(string cardId)
        {
            if (investigatorSelectorInteractor.InvestigatorSelected == null) return false;
            if (SelectionIsFull) return false;
            if (!IsThisCardAllowed(cardId)) return false;
            if ((cardInfoInteractor.GetQuantity(cardId)) - AmountSelectedOfThisCard(cardId) <= 0) return false;
            return true;
        }

        public bool IsManadatoryCard(string cardId) => InvestigatorSelected.MandatoryCards.Contains(cardId);

        private int AmountSelectedOfThisCard(string cardId) =>
            investigatorRepository.InvestigatorsList.Select(i => i.Deck.FindAll(b => b == cardId).Count).Sum();

        private bool IsThisCardAllowed(string cardId) => InvestigatorSelected.DeckBuilding.AllowedCards().Contains(cardId);
    }
}
