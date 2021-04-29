using Arkham.Model;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class ContinueButtonPresenter : IInitializable
    {
        [Inject] private readonly CampaignChangeEventDomain scenarioChanged;
        [Inject] private readonly ContinueGameInteractor continueGame;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            scenarioChanged.Subscribe(DesactiveButton);
            continueButton.Desactive(!continueGame.CanContinue());
        }

        /*******************************************************************/
        private void DesactiveButton(string scenario) => continueButton.Desactive(scenario == null);
    }
}
