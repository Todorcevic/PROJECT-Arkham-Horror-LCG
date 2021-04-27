using Zenject;
using Arkham.Interactors;
using Arkham.EventData;
using Arkham.Repositories;

namespace Arkham.Views
{
    public class CardsQuantityPresenter : IInitializable
    {
        [Inject] private readonly ICardAddedEvent addCardEvent;
        [Inject] private readonly ICardRemovedEvent removeCardEvent;
        [Inject] private readonly IInvestigatorSelectedEvent selectInvestigatorEvent;
        [Inject] private readonly IInvestigatorSelectedInfo currentInvestigator;
        [Inject] private readonly CardsQuantityView cardsQuantityView;

        private string AmountCards => currentInvestigator.Info.AmountCardsSelected.ToString();
        private string DeckSize => currentInvestigator.Info.DeckSize.ToString();

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
