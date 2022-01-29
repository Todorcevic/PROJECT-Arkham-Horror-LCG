using Zenject;

namespace Arkham.Application.MainMenu
{
    public class StartApplicationUseCase
    {
        [Inject] private readonly ApplicationValues applicationValues;
        [Inject] private readonly DataMapperService dataMapperService;
        [Inject] private readonly MainPanelPresenter panelPresenter;
        [Inject] private readonly StartGameUseCase startGame;
        [Inject] private readonly ButtonsPresenter buttonsPresenter;

        /*******************************************************************/
        public void Init()
        {
            UpdateApplication();
            UpdateView();

            void UpdateApplication() => dataMapperService.LoadProgress();

            void UpdateView()
            {
                buttonsPresenter.AutoActivateVisibilitySwitch();
                if (applicationValues.ContinueGame) startGame.ContinueGame();
                else panelPresenter.ChooseHomePanel();
            }
        }
    }
}
