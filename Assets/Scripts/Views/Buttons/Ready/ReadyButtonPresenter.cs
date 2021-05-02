using Arkham.Model;
using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class ReadyButtonPresenter : IInitializable
    {
        [Inject] private readonly AddInvestigatorEventDomain investigatorAddedEvent;
        [Inject] private readonly RemoveInvestigatorEventDomain investigatorRemovedEvent;
        [Inject] private readonly RemoveCardEventDomain cardRemovedEvent;
        [Inject] private readonly AddCardEventDomain cardAddedEvent;
        [Inject] private readonly Selector selectorRepository;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;

        /*******************************************************************/
        public void Initialize()
        {
            investigatorAddedEvent.Subscribe((_) => UpdateButton());
            investigatorRemovedEvent.Subscribe((_) => UpdateButton());
            cardAddedEvent.Subscribe((_) => UpdateButton());
            cardRemovedEvent.Subscribe((_) => UpdateButton());
        }

        public void UpdateButton() => readyButton.Desactive(!selectorRepository.IsReady);
    }
}
