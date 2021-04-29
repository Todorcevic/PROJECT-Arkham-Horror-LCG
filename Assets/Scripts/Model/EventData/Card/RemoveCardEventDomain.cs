using System;
using Zenject;

namespace Arkham.Model
{
    public class RemoveCardEventDomain
    {
        public event Action<string> DeckCardRemoved;
        [Inject] private readonly CurrentInvestigatorInteractor investigatorSelectedInfo;
        [Inject] private readonly InvestigatorSelectorRepository investigatorSelectorInfo;
        [Inject] private readonly InvestigatorInfoRepository investigatorInfo;

        private InvestigatorInfo Info =>
            investigatorInfo.Get(investigatorSelectorInfo.CurrentInvestigatorSelected);

        public bool RemoveCard(string cardId)
        {
            if (investigatorSelectedInfo.IsMandatoryCard(cardId)) return false;
            Info.Deck.Remove(cardId);
            DeckCardRemoved?.Invoke(cardId);
            return true;
        }
    }
}
