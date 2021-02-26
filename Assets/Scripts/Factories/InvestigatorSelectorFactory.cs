using Arkham.Controllers;
using Arkham.Presenters;
using Arkham.Views;
using Zenject;

namespace Arkham.Factories
{
    public class InvestigatorSelectorFactory : IInvestigatorSelectorFactory
    {
        [Inject] private readonly IInvestigatorSelectorController investigatorSelectorController;
        [Inject] private readonly IInvestigatorSelectorPresenter investigatorSelectorPresenter;

        /*******************************************************************/
        public void BuildSelectors()
        {
            foreach (IInvestigatorSelectorView selectorView in investigatorSelectorPresenter.Selectors)
            {
                selectorView.Init();
                investigatorSelectorController.Init(selectorView);
            }

            investigatorSelectorPresenter.Init();
        }
    }
}
