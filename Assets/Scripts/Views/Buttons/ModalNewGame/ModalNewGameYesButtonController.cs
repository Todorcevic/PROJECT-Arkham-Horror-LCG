﻿using Arkham.EventData;
using Zenject;

namespace Arkham.Views
{
    public class ModalNewGameYesButtonController : IInitializable
    {
        [Inject] private readonly IStartGame startGame;
        [Inject] private readonly IChangeScenario changeScenario;
        [Inject(Id = "ModalNewGameYesButton")] private readonly IClickable yesButton;
        [Inject(Id = "MainPanelsManager")] private readonly IPanelsManager panelsManager;
        [Inject(Id = "ChooseCampaignPanel")] private readonly PanelView chooseCardPanel;

        /*******************************************************************/
        void IInitializable.Initialize() => yesButton.AddAction(Clicked);

        private void Clicked()
        {
            startGame.NewGame();
            changeScenario.SelectingScenario(null);
            panelsManager.SelectPanel(chooseCardPanel);
        }
    }
}