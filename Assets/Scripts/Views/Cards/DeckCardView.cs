using Arkham.EventData;
using Arkham.Presenters;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class DeckCardView : CardView, IDeckCardVisualizable, IPointerClickHandler
    {
        [Inject] private readonly IAddCard addCard;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            effects.ClickEffect();
            addCard.AddDeckCard(Id);
        }
    }
}
