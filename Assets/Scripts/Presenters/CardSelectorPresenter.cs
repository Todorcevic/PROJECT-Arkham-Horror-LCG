using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Views;
using UnityEngine;
using Zenject;

namespace Arkham.Presenters
{
    public class CardSelectorPresenter : ICardSelectorPresenter
    {
        [Inject] private readonly ICardSelectorsManager cardSelectorsManager;
        [Inject] private readonly IDeckCardsManager deckCardsManager;
        [Inject] private readonly IDeckBuilderInteractor deckBuilderInteractor;

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

        public void AddCard(string cardId)
        {
            //SetInvestigatorInVoidSelector(investigatorId).MoveTo(investigatorManager.AllCards[investigatorId].Transform);
            //ArrangeSelectors();
        }

        public void RemoveCard(string cardId)
        {
            //SetInvestigatorInVoidSelector(investigatorId).MoveTo(investigatorManager.AllCards[investigatorId].Transform);
            //ArrangeSelectors();
        }

        private ISelectorView SetCardInVoidSelector(string cardId)
        {
            ISelectorView selector = cardSelectorsManager.GetVoidSelector();
            Sprite spriteCard = deckCardsManager.GetSpriteCard(cardId);
            selector.SetSelector(cardId, spriteCard);
            return selector;
        }
    }
}
