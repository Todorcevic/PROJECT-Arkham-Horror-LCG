using Zenject;

namespace Arkham.Application.MainMenu
{
    public class SwitchVisibilityUseCase
    {
        [Inject] private readonly PlayerPrefService playerPrefs;
        [Inject] private readonly InvestigatorsCardPresenter investigatorCardPresenter;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;

        /*******************************************************************/
        public void RefreshVisibility() => UpdateView();

        public void Switch(bool isOn)
        {
            UpdateApplication(isOn);
            UpdateView();
        }

        private void UpdateApplication(bool isOn) => playerPrefs.SaveCardsVisibility(isOn);

        private void UpdateView()
        {
            investigatorCardPresenter.RefreshInvestigatorsVisibility();
            deckCardPresenter.RefreshCardsVisibility();
        }
    }
}
