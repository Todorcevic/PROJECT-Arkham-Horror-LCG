using System.Collections.Generic;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class BackButtonController : IInitializable
    {
        [Inject(Id = "BackButton")] private readonly List<ButtonView> backButtons;
        [Inject(Id = "MainPanelsManager")] private readonly PanelsMediator panelsManager;
        [Inject(Id = "HomePanel")] private readonly PanelView homePanel;
        [Inject] private readonly DataContextService dataPersistence;

        /*******************************************************************/
        void IInitializable.Initialize() => backButtons.ForEach(button => button.ClickAction += Clicked);

        /*******************************************************************/
        private void Clicked()
        {
            dataPersistence.SaveProgress();
            panelsManager.SelectPanel(homePanel);
        }
    }
}
