using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class SearchController : IInitializable, ICardSearch
    {
        [Inject(Id = "InputSearch")] private readonly InputFieldView inputFieldView;
        [Inject] private readonly InvestigatorCardVisibilityPresenter investigatorVisibility;
        [Inject] private readonly DeckCardVisibilityPresenter cardVisibility;

        public string TextToSearch => inputFieldView.CurrentText;

        /*******************************************************************/
        void IInitializable.Initialize() => inputFieldView.AddUpdateAction(Updated);

        /*******************************************************************/
        public void Updated()
        {
            investigatorVisibility.RefreshInvestigatorsVisibility();
            cardVisibility.RefreshCardsVisibility();
        }
    }
}
