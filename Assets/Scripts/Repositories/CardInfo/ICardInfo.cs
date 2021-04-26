using Arkham.Entities;
using System;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICardInfo
    {
        CardInfo Get(string cardId);
        List<CardInfo> FindAll(Predicate<CardInfo> filter);
        bool ThisCardContainThisText(string cardId, string textToSearch);
    }
}
