using Arkham.Entities;
using System;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface IInvestigatorInfo
    {
        InvestigatorInfo Get(string investigatorId);
        List<InvestigatorInfo> FindAll(Predicate<InvestigatorInfo> filter);
        bool Exists(Predicate<InvestigatorInfo> filter);
        int AmountSelectedOfThisCard(string cardId);
    }
}
