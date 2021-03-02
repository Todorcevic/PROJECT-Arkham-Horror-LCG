using Arkham.Entities;
using Arkham.Repositories;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Interactors
{
    public class InvestigatorInfoInteractor : IInvestigatorInfoInteractor
    {
        [Inject] private readonly IInvestigatorRepository investigatorRepository;

        /*******************************************************************/
        public int GetThisCardAmountInDeck(string investigatorId, string cardId) =>
            GetInvestigatorInfo(investigatorId).FullDeck.FindAll(id => id == cardId).Count;

        public List<string> GetFullDeck(string investigatordId) =>
            GetInvestigatorInfo(investigatordId).FullDeck; //TODO investigatorId = NULL;

        private InvestigatorInfo GetInvestigatorInfo(string investigatordId) =>
            investigatorRepository.InvestigatorsList.Find(investigator => investigator.Id == investigatordId);
    }
}
