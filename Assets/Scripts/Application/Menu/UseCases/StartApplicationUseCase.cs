using Zenject;

namespace Arkham.Application.MainMenu
{
    public class StartApplicationUseCase
    {
        [Inject] private readonly ApplicationValues applicationValues;
        [Inject] private readonly DataMapperService dataMapperService;
        [Inject] private readonly MainPanelPresenter panelPresenter;
        [Inject] private readonly ContinueGameUseCase continueGameUseCase;

        /*******************************************************************/
        public void Init()
        {
            UpdateApplication();
            UpdateView();

            void UpdateApplication() => dataMapperService.LoadProgress();

            void UpdateView()
            {
                if (applicationValues.IsContinuosGame) continueGameUseCase.ContinueGame();
                else panelPresenter.ChooseHomePanel();
            }
        }
    }
}
