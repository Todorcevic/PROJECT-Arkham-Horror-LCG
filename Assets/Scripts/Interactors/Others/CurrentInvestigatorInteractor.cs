using Arkham.Entities;
using Arkham.Repositories;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Interactors
{
    public class CurrentInvestigatorInteractor : ICurrentInvestigatorInteractor
    {
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        [Inject] private readonly IInvestigatorRepository investigatorRepository;
        [Inject] private readonly IInvestigatorInfoInteractor investigatorInfoInteractor;

        public string Id => investigatorSelectorRepository.CurrentInvestigatorSelected;
        public int DeckSize => Info?.DeckBuilding.DeckSize ?? 0;
        public int AmountCardsSelected => Info?.Deck.Count ?? 0;
        public List<string> AllowedCards => Info.DeckBuilding.AllowedCards();
        public List<string> MandatoryCards => Info.MandatoryCards;
        public List<string> Deck => Info.Deck;
        public bool SelectionIsFull => AmountCardsSelected >= DeckSize;
        public bool SelectionIsNotFull => AmountCardsSelected == DeckSize - 1;
        public int Xp => Info.Xp;

        /*******************************************************************/
        public int GetAmountOfThisCardInDeck(string cardId) =>
            investigatorInfoInteractor.GetAmountOfThisCardInDeck(Id, cardId);

        private InvestigatorInfo Info =>
            investigatorRepository.GetInvestigatorInfo(investigatorSelectorRepository.CurrentInvestigatorSelected);
    }
}
