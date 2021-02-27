using Arkham.Controllers;
using Arkham.Presenters;
using Arkham.Views;
using Zenject;

namespace Arkham.Factories
{
    public class CardSelectorFactory : ICardSelectorFactory
    {
        [Inject] private readonly ICardSelectorController investigatorSelectorController;
        [Inject] private readonly ICardSelectorPresenter cardSelectorPresenter;

        /*******************************************************************/
        public void BuildSelectors()
        {
            foreach (ICardSelectorView selectorView in cardSelectorPresenter.Selectors)
            {
                selectorView.Init();
                investigatorSelectorController.Init(selectorView);
            }

            cardSelectorPresenter.Init();
        }
    }
}
