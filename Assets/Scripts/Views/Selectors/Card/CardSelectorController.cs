using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class CardSelectorController
    {
        [Inject] private readonly RemoveCardEventDomain investigatorSelected;
        [Inject] private readonly CardSelectorsManager manager;

        /*******************************************************************/
        public void Clicked(string cardId)
        {
            if (!investigatorSelected.RemoveCard(cardId))
                manager.GetSelectorByCardIdOrEmpty(cardId).CantRemoveAnimation();
        }
    }
}
