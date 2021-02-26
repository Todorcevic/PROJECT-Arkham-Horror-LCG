using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Views;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Presenters
{
    public class CardSelectorPresenter : ICardSelectorPresenter
    {
        [Inject(Id = "CardsSelector")] private readonly ISelectorsManager selectorsManager;
        [Inject(Id = "DecksManager")] private readonly ICardsManager cardsManager;
        [Inject] private readonly IDeckBuilderInteractor deckBuilderInteractor;

        public List<ICardSelectorView> Selectors => selectorsManager.Selectors<ICardSelectorView>();

        /*******************************************************************/
        public void Init()
        {
            deckBuilderInteractor.DeckCardAdded += AddCard;
            deckBuilderInteractor.DeckCardRemoved += RemoveCard;
            //investigatorSelectorInteractor.InvestigatorSelectedChanged += SelectInvestigator;
            //investigatorSelectorInteractor.InvestigatorAdded += AddInvestigator;
            //investigatorSelectorInteractor.InvestigatorRemoved += RemoveInvestigator;
            //InitializeSelectors();
            //investigatorSelectorInteractor.SelectInvestigator(LeadInvestigator);
        }

        private void AddCard(string cardId)
        {
            SetCardInVoidSelector(cardId);
            //SetInvestigatorInVoidSelector(investigatorId).MoveTo(investigatorManager.AllCards[investigatorId].Transform);
            //ArrangeSelectors();
        }

        private void RemoveCard(string cardId)
        {
            //SetInvestigatorInVoidSelector(investigatorId).MoveTo(investigatorManager.AllCards[investigatorId].Transform);
            //ArrangeSelectors();
        }

        private ICardSelectorView SetCardInVoidSelector(string cardId)
        {
            ICardSelectorView selector = selectorsManager.GetVoidSelector<ICardSelectorView>();
            Sprite spriteCard = cardsManager.GetSpriteCard(cardId);
            selector.SetSelector(cardId, spriteCard);
            selector.ActiveSelector(cardId != null);
            return selector;
        }
    }
}
