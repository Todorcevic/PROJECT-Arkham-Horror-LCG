using Arkham.Models;
using Arkham.Repositories;
using System;
using System.Linq;
using Zenject;

namespace Arkham.Interactors
{
    public class DeckBuilderInteractor : IDeckBuilderInteractor
    {
        [Inject] private readonly IInvestigatorRepository investigatorRepository;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        public event Action<string> DeckCardAdded;
        public event Action<string> DeckCardRemoved;
        private InvestigatorInfo InvestigatorSelected => GetInvestigatorById(investigatorSelectorInteractor.InvestigatorSelected);
        public int DeckSize => InvestigatorSelected.DeckBuilding.DeckSize;
        public int CardsAmountSelected => InvestigatorSelected.Deck.Count;
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

        public int AmountSelectedOfThisCard(string idCard) =>
            investigatorRepository.InvestigatorsList.Select(i => i.Deck.FindAll(b => b == idCard).Count).Sum();
    }
}
