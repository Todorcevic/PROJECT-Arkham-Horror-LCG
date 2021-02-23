using Arkham.Controllers;
using Arkham.Presenters;
using Arkham.Views;
using Zenject;

namespace Arkham.Factories
{
    public class InvestigatorSelectorFactory : IInvestigatorSelectorFactory
    {
        [Inject] private readonly IInvestigatorSelectorController selectorController;
        [Inject] private readonly IInvestigatorSelectorPresenter selectorPresenter;

        /*******************************************************************/
        public void BuildSelectors()
        {
            foreach (IInvestigatorSelectorView selectorView in selectorPresenter.Selectors)
            {
                selectorView.Init();
                selectorController.Init(selectorView);
            }

            selectorPresenter.Init();
        }
    }
}
