using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class DeckCardInput : CardInput, IPointerClickHandler
    {
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly AddCardUseCase addCardUseCase;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (InvestigatorSelectorView.IsMoving) return;
            audioInteractable.ClickSound();
            if (cardView.IsInactive) cardView.CantAdd();
            else addCardUseCase.AddCard(cardView.Id, investigatorSelectorManager.InvestigatorSelected);
        }
    }
}
