using Zenject;

namespace Arkham.Application.MainMenu
{
    public class StartApplicationUseCase
    {
        [Inject] private readonly ApplicationValues applicationValues;
        [Inject] private readonly DataMapperService dataMapperService;
        [Inject] private readonly PanelPresenter panelPresenter;
        [Inject] private readonly StartGameUseCase startGame;

        /*******************************************************************/
        public void Init()
        {
            UpdateApplication();
            UpdateView();

            void UpdateApplication() => dataMapperService.LoadProgress();

            void UpdateView()
            {
                if (applicationValues.ContinueGame) startGame.ContinueGame();
                else panelPresenter.ChooseHomePanel();
            }
        }
    }
}
