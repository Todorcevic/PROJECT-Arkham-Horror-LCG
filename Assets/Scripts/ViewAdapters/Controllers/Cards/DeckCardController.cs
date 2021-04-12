using Arkham.EventData;
using Arkham.Views;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class DeckCardController : CardController, IPointerClickHandler
    {
        [Inject] private readonly IAddCard addCard;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging || cardView.IsInactive) return;
            cardView.ClickEffect();
            addCard.AddDeckCard(cardView.Id);
        }
    }
}
