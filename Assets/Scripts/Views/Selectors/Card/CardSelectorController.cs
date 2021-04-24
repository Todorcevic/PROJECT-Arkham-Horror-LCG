using Arkham.EventData;
using Arkham.Interactors;
using Zenject;

namespace Arkham.Views
{
    public class CardSelectorController : ICardSelectorController
    {
        [Inject] private readonly IRemoveCard removeCard;
        [Inject] private readonly IClickableCards clickableCards;
        [Inject] private readonly ICardSelectorsManager manager;

        /*******************************************************************/
        public void Clicked(string cardId)
        {
            if (clickableCards.IsClickable(cardId)) removeCard.RemoveDeckCard(cardId);
            else manager.GetSelectorByCardIdOrEmpty(cardId).CantRemoveAnimation();
        }
    }
}
