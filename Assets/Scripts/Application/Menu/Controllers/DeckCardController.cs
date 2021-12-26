using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class DeckCardController : CardController
    {
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly AddCardUseCase addCardUseCase;

        /*******************************************************************/
        protected override void Clicked(PointerEventData eventData)
        {
            audioInteractable.ClickSound();
            if (cardView.IsInactive) CantAdd();
            else addCardUseCase.AddCard(cardView.Id, investigatorSelectorManager.InvestigatorSelected);
        }
    }
}
