using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CardsQuantityPresenter
    {
        [Inject] private readonly CardsQuantityView cardQuantityView;

        /*******************************************************************/
        public void Update(Investigator investigator) =>
            cardQuantityView.Refresh(investigator?.AmountCardsSelected.ToString(), investigator?.DeckBuilding.DeckSize.ToString());
    }
}
