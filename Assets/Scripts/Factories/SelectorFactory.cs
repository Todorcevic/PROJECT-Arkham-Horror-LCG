using Arkham.Controllers;
using Arkham.Presenters;
using Arkham.Views;
using Zenject;

namespace Arkham.Factories
{
    public class SelectorFactory : ISelectorFactory
    {
        [Inject] private readonly ISelectorController selectorController;
        [Inject] private readonly ISelectorPresenter selectorPresenter;

        /*******************************************************************/
        public void BuildSelectors()
        {
            foreach (ISelectorView selector in selectorPresenter.Selectors)
                selectorController.Init(selector);

            selectorPresenter.Init();
        }
    }
}
