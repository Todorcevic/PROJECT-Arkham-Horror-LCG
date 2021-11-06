using Arkham.Services;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application
{
    public class InvestigatorCardController : CardController
    {
        [Inject] private readonly AddInvestigatorUseCase addInvestigatorUseCase;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectors;
        [Inject(Id = "InvestigatorsSelector")] private readonly PlaceHoldersZone placeZone;

        /*******************************************************************/
        protected override void Clicked(PointerEventData eventData)
        {
            audioInteractable.ClickSound();
            if (investigatorSelectors.CurrentInvestigatorId != cardView.Id)
                selectInvestigatorUseCase.Select(cardView.Id);
            if (cardView.IsInactive) CantAdd();
            else addInvestigatorUseCase.Add(cardView.Id);
        }
    }
}
