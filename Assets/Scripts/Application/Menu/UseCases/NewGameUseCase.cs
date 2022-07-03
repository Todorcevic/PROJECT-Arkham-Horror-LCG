using Zenject;

namespace Arkham.Application.MainMenu
{
    public class NewGameUseCase
    {
        [Inject] private readonly MainMenuPersistenceService dataMapperService;
        [Inject] private readonly MainPanelPresenter panelPresenter;

        /*******************************************************************/
        public void StartNewGame()
        {
            UpdateApplication();
            UpdateView();

            void UpdateApplication()
            {
                dataMapperService.RemoveProgress();
                dataMapperService.LoadProgress();
            }

            void UpdateView() => panelPresenter.ChooseCampaignPanel();
        }
    }
}

