using DG.Tweening;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application
{
    public class InvestigatorCardController : CardController
    {
        [Inject] private readonly AddInvestigatorUseCase addInvestigatorUseCase;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectors;

        /*******************************************************************/
        protected override void Clicked(PointerEventData eventData)
        {
            if (DOTween.IsTweening(InvestigatorSelectorView.MOVE_ANIMATION)) return;
            audioInteractable.ClickSound();
            if (investigatorSelectors.InvestigatorSelected != cardView.Id)
                selectInvestigatorUseCase.Select(cardView.Id);
            if (cardView.IsInactive) CantAdd();
            else addInvestigatorUseCase.Add(cardView.Id);
        }
    }
}
