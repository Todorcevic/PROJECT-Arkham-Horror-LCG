using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class SearchController : IInitializable
    {
        [Inject(Id = "InputSearch")] private readonly InputFieldView inputFieldView;
        [Inject] private readonly InvestigatorsCardPresenter investigatorVisibility;
        [Inject] private readonly DeckCardPresenter cardVisibility;

        /*******************************************************************/
        void IInitializable.Initialize() => inputFieldView.UpdateAction += Updated;

        /*******************************************************************/
        private void Updated()
        {
            investigatorVisibility.RefreshInvestigatorsVisibility();
            cardVisibility.RefreshCardsVisibility();
        }
    }
}
