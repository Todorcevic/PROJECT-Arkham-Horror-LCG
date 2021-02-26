using Arkham.Models;
using Arkham.Repositories;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Zenject;

namespace Arkham.Interactors
{
    public class DeckBuilderInteractor : IDeckBuilderInteractor
    {
        [Inject] private readonly IInvestigatorRepository investigatorRepository;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        public event Action<string> DeckCardAdded;
        public event Action<string> DeckCardRemoved;
        private InvestigatorInfo InvestigatorSelected => GetInvestigatorById(investigatorSelectorInteractor.InvestigatorSelected);

        /*******************************************************************/
        public InvestigatorInfo GetInvestigatorById(string investigatorId) =>
            investigatorRepository.InvestigatorsList.Find(investigator => investigator.Id == investigatorId);

        public void AddDeckCard(string deckCardId)
        {
            if (InvestigatorSelected.Deck == null) InvestigatorSelected.Deck = new List<string>();
            InvestigatorSelected.Deck.Add(deckCardId);
            DeckCardAdded?.Invoke(deckCardId);
        }

        public void RemoveDeckCard(string deckCardId)
        {
            InvestigatorSelected.Deck.Remove(deckCardId);
            DeckCardRemoved?.Invoke(deckCardId);
        }
    }
}
