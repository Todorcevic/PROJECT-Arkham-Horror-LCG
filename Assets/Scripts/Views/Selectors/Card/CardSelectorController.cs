using Arkham.Interactors;
using Zenject;

namespace Arkham.Views
{
    public class CardSelectorController : ICardSelectorController
    {
        [Inject] private readonly IInvestigatorSelected investigatorSelected;
        [Inject] private readonly ICardSelectorsManager manager;

        /*******************************************************************/
        public void Clicked(string cardId)
        {
            if (!investigatorSelected.RemoveCard(cardId))
                manager.GetSelectorByCardIdOrEmpty(cardId).CantRemoveAnimation();
        }
    }
}
