using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class DeckCardController : CardController, IPointerClickHandler
    {
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly AddCardUseCase addCardUseCase;

        DeckCardView DeckCardView => cardView as DeckCardView;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            DeckCardView.PointerClick();
            if (!cardView.IsInactive)
                addCardUseCase.AddCard(cardView.Id, investigatorSelectorManager.InvestigatorSelected);
        }
    }
}
