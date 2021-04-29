using Arkham.Model;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class AddInvestigatorPresenter : IInitializable, IAddInvestigatorPresenter
    {
        [Inject] private readonly InvestigatorSelectorEventDomain investigatorAddedEvent;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly ICardsManager investigatorCardsManager;
        [Inject] private readonly IInvestigatorLeadPresenter selectorLead;
        [Inject] private readonly ICardShowerPresenter cardShowerPresenter;
        [Inject(Id = "InvestigatorPlaceHolderZone")] private readonly RectTransform placeHoldersZone;

        /*******************************************************************/
        public void Initialize() => investigatorAddedEvent.Add(AddInvestigator);

        /*******************************************************************/
        public void InitInvestigator(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
            SetThisSelectorWithThisInvestigator(selector, investigatorId);
            selector.PosicionateCardOn();
        }

        private void AddInvestigator(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
            SetThisSelectorWithThisInvestigator(selector, investigatorId);
            selectorLead.SetLeadSelector();
            Animation(selector);
        }

        private void SetThisSelectorWithThisInvestigator(InvestigatorSelectorView selector, string investigatorId)
        {
            Sprite spriteCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            selector.SetTransform(placeHoldersZone);
            selector.SetSelector(investigatorId, spriteCard);
            investigatorSelectorsManager.RebuildPlaceHolders();
        }

        private async void Animation(InvestigatorSelectorView selector)
        {
            await cardShowerPresenter.AddInvestigatorAnimation(selector.PlaceHolderPosition);
            selector.SetImageAnimation();
        }
    }
}
