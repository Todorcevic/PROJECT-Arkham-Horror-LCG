using Arkham.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Arkham.Repositories
{
    [DataContract]
    public class InvestigatorInfoRepository : IInvestigatorInfoLoader, IInvestigatorInfo
    {
        [DataMember] public List<InvestigatorInfo> InvestigatorsList { get; set; }

        /*******************************************************************/
        public InvestigatorInfo Get(string investigatorId) =>
            InvestigatorsList.Find(c => c.Id == investigatorId);

        public List<InvestigatorInfo> FindAll(Predicate<InvestigatorInfo> filter) =>
            InvestigatorsList.FindAll(filter);

        public bool Exists(Predicate<InvestigatorInfo> filter) => InvestigatorsList.Exists(filter);

        public int AmountSelectedOfThisCard(string cardId) =>
            InvestigatorsList.Select(i => i.Deck.FindAll(c => c == cardId).Count).Sum();
    }
}
