using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ReturnMainMenuUseCase
    {
        [Inject] private readonly MainMenuPersistenceService dataPersistence;
        [Inject] private readonly MainPanelPresenter panelPresenter;

        /*******************************************************************/
        public void ReturnHome()
        {
            UpdateApplication();
            UpdateView();

            void UpdateApplication() => dataPersistence.SaveProgress();

            void UpdateView() => panelPresenter.ChooseHomePanel();
        }
    }
}
