using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class SearchController : IInitializable, ICardSearchable
    {
        [Inject] private readonly InvestigatorSelectionInteractor investigatorSelectionFilter;
        [Inject(Id = "InputSearch")] private readonly InputFieldView inputFieldView;
        [Inject] private readonly InvestigatorsCardPresenter investigatorVisibility;
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
