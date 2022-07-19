using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class InvestigatorCardInput : CardInput, IPointerClickHandler
    {
        [Inject] private readonly AddInvestigatorUseCase addInvestigatorUseCase;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (InvestigatorSelectorView.IsMoving) return;
            audioInteractable.ClickSound();
            selectInvestigatorUseCase.Select(cardView.Id);
            if (cardView.IsInactive) cardView.CantAdd();
            else addInvestigatorUseCase.Add(cardView.Id);
        }
    }
}
