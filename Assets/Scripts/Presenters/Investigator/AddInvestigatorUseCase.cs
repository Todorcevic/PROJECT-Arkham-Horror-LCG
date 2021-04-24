using Arkham.EventData;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class AddInvestigatorUseCase : IInitializable, IAddInvestigatorUseCase
    {
        [Inject] private readonly IAddInvestigatorEvent addInvestigatorEvent;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly ICardsManager investigatorCardsManager;
        [Inject] private readonly ILeadInvestigatorUseCase selectorLead;
        [Inject] private readonly ICardShowerPresenter cardShowerPresenter;
        [Inject(Id = "InvestigatorPlaceHolderZone")] private readonly RectTransform placeHoldersZone;

        /*******************************************************************/
        public void Initialize() => addInvestigatorEvent.AddAction(AddInvestigator);

        /*******************************************************************/
        public void AddInvestigator(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
            Sprite spriteCard = investigatorCardsManager.GetSpriteCard(investigatorId);
            selector.SetTransform(placeHoldersZone);
            selector.SetSelector(investigatorId, spriteCard);
            selectorLead.SetLeadSelector();
            Animation(selector);
        }

        private async void Animation(InvestigatorSelectorView selector)
        {
            investigatorSelectorsManager.RebuildPlaceHolders();
            await cardShowerPresenter.AddInvestigatorAnimation(selector.PlaceHolderPosition);
            selector.SetImageAnimation();
        }
    }
}
