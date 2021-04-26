using Zenject;
using Arkham.Interactors;
using Arkham.EventData;
using Arkham.Repositories;

namespace Arkham.Views
{
    public class CardsQuantityPresenter : IInitializable
    {
        [Inject] private readonly IAddCardEvent addCardEvent;
        [Inject] private readonly IRemoveCardEvent removeCardEvent;
        [Inject] private readonly IInvestigatorSelectedEvent selectInvestigatorEvent;
        [Inject] private readonly ICurrentInvestigatorInteractor currentInvestigator;
        [Inject] private readonly CardsQuantityView cardsQuantityView;

        private string AmountCards => currentInvestigator.AmountCardsSelected.ToString();
        private string DeckSize => currentInvestigator.DeckSize.ToString();

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            addCardEvent.AddAction((_) => UpdateData());
            removeCardEvent.AddAction((_) => UpdateData());
            selectInvestigatorEvent.Subscribe((_) => UpdateData());
        }

        /*******************************************************************/
        private void UpdateData()
        {
            cardsQuantityView.SetCardsAmount(AmountCards);
            cardsQuantityView.SetDeckSize(DeckSize);
        }
    }
}
