using Arkham.Interactors;
using Arkham.Repositories;
using Zenject;

namespace Arkham.Views
{
    public class ContinueButtonPresenter : IInitializable
    {
        [Inject] private readonly IScenarioChangedEvent changeCampaignEventData;
        [Inject] private readonly IContinueGame continueGame;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            changeCampaignEventData.Subscribe(DesactiveButton);
            continueButton.Desactive(!continueGame.CanContinue());
        }

        /*******************************************************************/
        private void DesactiveButton(string scenario) => continueButton.Desactive(scenario == null);


    }
}
