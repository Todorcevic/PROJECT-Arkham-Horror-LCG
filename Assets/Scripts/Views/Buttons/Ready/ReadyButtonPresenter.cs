using Arkham.Model;
using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class ReadyButtonPresenter : IInitializable
    {
        [Inject] private readonly AddInvestigatorEventDomain addInvestigatorEvent;
        [Inject] private readonly RemoveInvestigatorEventDomain removeInvestigatorEvent;
        [Inject] private readonly RemoveCardEventDomain removeCardEvent;
        [Inject] private readonly AddCardEventDomain addCardEvent;
        [Inject] private readonly StartGameEventDomain startGameEvent;
        [Inject] private readonly Selector selectorRepository;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;

        /*******************************************************************/
        public void Initialize()
        {
            addInvestigatorEvent.Subscribe((_) => UpdateButton());
            removeInvestigatorEvent.Subscribe((_) => UpdateButton());
            startGameEvent.Subscribe((_) => UpdateButton());
            addCardEvent.Subscribe((_) => UpdateButton());
            removeCardEvent.Subscribe((_) => UpdateButton());
        }

        private void UpdateButton() => readyButton.Desactive(!selectorRepository.IsReady);
    }
}
