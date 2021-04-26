using Arkham.Entities;
using Arkham.Repositories;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Interactors
{
    public class CurrentInvestigatorInteractor : ICurrentInvestigatorInteractor
    {
        [Inject] private readonly IInvestigatorSelectorInfo investigatorSelectorInfo;
        [Inject] private readonly IInvestigatorInfo investigatorRepository;

        public string Id => investigatorSelectorInfo.CurrentInvestigatorSelected;
        public int DeckSize => Info?.DeckSize ?? 0;
        public int AmountCardsSelected => Info?.AmountCardsSelected ?? 0;
        public List<string> AllowedCards => Info.DeckBuilding.AllowedCards();
        public List<string> MandatoryCards => Info.MandatoryCards;
        public List<string> Deck => Info.Deck;
        public bool SelectionIsFull => Info.SelectionIsFull;
        public bool SelectionIsNotFull => AmountCardsSelected == DeckSize - 1;
        public int Xp => Info.Xp;

        /*******************************************************************/
        public int GetAmountOfThisCardInDeck(string cardId) =>
            investigatorRepository.Get(Id).GetAmountOfThisCardInDeck(cardId);

        private InvestigatorInfo Info => investigatorRepository.Get(Id);
    }
}
