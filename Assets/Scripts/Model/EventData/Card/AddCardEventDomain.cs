using System;
using Zenject;

namespace Arkham.Model
{
    public class AddCardEventDomain
    {
        public event Action<string> DeckCardAdded;
        [Inject] private readonly InvestigatorSelectorRepository investigatorSelectorInfo;
        [Inject] private readonly InvestigatorInfoRepository investigatorInfo;

        private InvestigatorInfo Info =>
            investigatorInfo.Get(investigatorSelectorInfo.CurrentInvestigatorSelected);

        /*******************************************************************/
        public void AddCard(string deckCardId)
        {
            Info.Deck.Add(deckCardId);
            DeckCardAdded?.Invoke(deckCardId);
        }
    }
}
