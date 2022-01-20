using Zenject;

namespace Arkham.Application.MainMenu
{
    public class SwitchVisibilityUseCase
    {
        [Inject] private readonly PlayerPrefService playerPrefs;
        [Inject] private readonly InvestigatorsCardPresenter investigatorVisibility;
        [Inject] private readonly DeckCardPresenter cardVisibility;

        /*******************************************************************/
        public void Switch(bool isOn)
        {
            UpdateApplication(isOn);
            UpdateView();
        }

        private void UpdateApplication(bool isOn) => playerPrefs.SaveCardsVisibility(isOn);

        private void UpdateView()
        {
            investigatorVisibility.RefreshInvestigatorsVisibility();
            cardVisibility.RefreshCardsVisibility();
        }
    }
}
