using Arkham.Entities;
using Arkham.Repositories;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Arkham.Interactors
{
    public class InvestigatorInfoInteractor : IInvestigatorInfoInteractor
    {
        [Inject] private readonly IInvestigatorRepository investigatorRepository;
        [Inject] private readonly ICardInfoRepository cardInfoRepository;

        /*******************************************************************/
        public int GetAmountOfThisCardInDeck(string investigatorId, string cardId) =>
            investigatorRepository.GetInvestigatorInfo(investigatorId).FullDeck.FindAll(id => id == cardId).Count;

        public List<string> GetFullDeck(string investigatorId) =>
            investigatorRepository.GetInvestigatorInfo(investigatorId).FullDeck;

        public int AmountSelectedOfThisCard(string cardId) =>
            investigatorRepository.InvestigatorsList.Select(i => i.Deck.FindAll(c => c == cardId).Count).Sum();

        public DeckBuildingRules GetDeckBuilding(string investigatorId) =>
            investigatorRepository.GetInvestigatorInfo(investigatorId).DeckBuilding;

        public bool IsRetired(string investigatorId) => investigatorRepository.GetInvestigatorInfo(investigatorId).IsRetired;

        public bool ISKilled(string investigatorId)
        {
            int physicTraumaAmount = investigatorRepository.GetInvestigatorInfo(investigatorId).PhysicTrauma;
            int healthAmount = cardInfoRepository.GetCardInfo(investigatorId).Health ?? 0;
            return physicTraumaAmount >= healthAmount;
        }

        public bool ISInsane(string investigatorId)
        {
            int mentalTraumaAmount = investigatorRepository.GetInvestigatorInfo(investigatorId).MentalTrauma;
            int sanityAmount = cardInfoRepository.GetCardInfo(investigatorId).Sanity ?? 0;
            return mentalTraumaAmount >= sanityAmount;
        }

        public bool IsEliminated(string investigatorId)
        {
            if (ISInsane(investigatorId)) return true;
            if (ISKilled(investigatorId)) return true;
            if (IsRetired(investigatorId)) return true;
            return false;
        }
    }
}
