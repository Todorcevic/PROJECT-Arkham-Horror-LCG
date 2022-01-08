using DG.Tweening;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class InvestigatorCardController : CardController, IPointerClickHandler
    {
        [Inject] private readonly AddInvestigatorUseCase addInvestigatorUseCase;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectors;

        InvestigatorCardView InvestigatorCardView => cardView as InvestigatorCardView;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (DOTween.IsTweening(InvestigatorSelectorView.MOVE_ANIMATION)) return;
            InvestigatorCardView.PointerClick();
            if (investigatorSelectors.InvestigatorSelected != cardView.Id)
                selectInvestigatorUseCase.Select(cardView.Id);
            if (!cardView.IsInactive) addInvestigatorUseCase.Add(cardView.Id);
        }
    }
}
