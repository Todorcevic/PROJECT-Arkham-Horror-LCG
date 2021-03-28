using Arkham.EventData;
using Arkham.Managers;
using Arkham.Views;
using Zenject;

namespace Arkham.Presenters
{
    public class ShowCardPresenter : IInitializable
    {
        [Inject] protected readonly IShowCard showCard;
        [Inject] protected readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly IAddInvestigatorEvent addInvestigatorEvent;
        [Inject] private readonly IAddCardEvent addCardEvent;

        /*******************************************************************/
        public void Initialize()
        {
            addInvestigatorEvent.AddAction(AddInvestigator);
            addCardEvent.AddAction(AddCard);
        }

        private void AddInvestigator(string InvestigatorId) => showCard.HidePreviewCard();

        private void AddCard(string cardId) => showCard.MoveAnimation();
    }
}
