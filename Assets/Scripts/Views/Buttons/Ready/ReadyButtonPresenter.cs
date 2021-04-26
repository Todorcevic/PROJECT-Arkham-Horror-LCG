using Arkham.EventData;
using Arkham.Interactors;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class ReadyButtonPresenter : IInitializable
    {
        [Inject] private readonly IRemoveCardEvent removeCardEvent;
        [Inject] private readonly IAddCardEvent addCardEvent;
        [Inject] private readonly IStartGameEvent startGameEvent;
        [Inject] private readonly IPlayGameInteractor playGameInteractor;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;

        /*******************************************************************/
        public void Initialize()
        {
            startGameEvent.AddAction(UpdateButton);
            addCardEvent.AddAction((_) => UpdateButton());
            removeCardEvent.AddAction((_) => UpdateButton());
        }

        private void UpdateButton() => readyButton.Desactive(!playGameInteractor.GameIsReadyToPlay);
    }
}
