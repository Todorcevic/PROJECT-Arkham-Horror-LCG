using DG.Tweening;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class InvestigatorCardInput : CardInput, IPointerClickHandler
    {
        [Inject] private readonly AddInvestigatorUseCase addInvestigatorUseCase;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectors;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (DOTween.IsTweening(InvestigatorSelectorView.MOVE_ANIMATION)) return;
            audioInteractable.ClickSound();
            if (investigatorSelectors.InvestigatorSelected != cardView.Id) selectInvestigatorUseCase.Select(cardView.Id);
            if (cardView.IsInactive) cardView.CantAdd();
            else addInvestigatorUseCase.Add(cardView.Id);
        }
    }
}
