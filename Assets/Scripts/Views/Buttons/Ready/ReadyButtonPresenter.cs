using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class ReadyButtonPresenter : IInitializable
    {
        [Inject] private readonly RemoveCardEventDomain removeCardEvent;
        [Inject] private readonly AddCardEventDomain addCardEvent;
        [Inject] private readonly StartGameEventDomain startGameEvent;
        [Inject] private readonly PlayGameInteractor playGameInteractor;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;

        /*******************************************************************/
        public void Initialize()
        {
            startGameEvent.GameStarted += (_) => UpdateButton();
            addCardEvent.DeckCardAdded += (_) => UpdateButton();
            removeCardEvent.DeckCardRemoved += (_) => UpdateButton();
        }

        private void UpdateButton() => readyButton.Desactive(!playGameInteractor.GameIsReadyToPlay);
    }
}
