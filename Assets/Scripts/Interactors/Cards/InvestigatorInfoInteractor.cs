using Arkham.Investigators;
using Arkham.Repositories;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Arkham.Interactors
{
    public class InvestigatorInfoInteractor : IInvestigatorInfoInteractor
    {
        [Inject] private readonly IInvestigatorRepository investigatorRepository;

        /*******************************************************************/
        public int GetAmountOfThisCardInDeck(string investigatorId, string cardId) =>
            investigatorRepository.GetInvestigatorInfo(investigatorId).FullDeck.FindAll(id => id == cardId).Count;

        public List<string> GetFullDeck(string investigatordId) =>
            investigatorRepository.GetInvestigatorInfo(investigatordId).FullDeck;

        public int AmountSelectedOfThisCard(string cardId) =>
            investigatorRepository.InvestigatorsList.Select(i => i.Deck.FindAll(c => c == cardId).Count).Sum();

        public DeckBuildingRules GetDeckBuilding(string investigatorId) =>
            investigatorRepository.GetInvestigatorInfo(investigatorId).DeckBuilding;
    }
}
